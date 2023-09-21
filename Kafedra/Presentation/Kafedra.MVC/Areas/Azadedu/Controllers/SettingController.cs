using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;

using Kafedra.Application.Utilities.Enums;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class SettingController : Controller
    {
       
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        private readonly ISettingService _settingService;
        private readonly ISettingRepository _settingRepository;
        private readonly KafedraContext _context;

        public SettingController(IFileService fileService, IWebHostEnvironment env, ISettingService settingService, ISettingRepository settingRepository, KafedraContext context)
        {

            _fileService = fileService;
            _env = env;
            _settingService = settingService;
            _settingRepository = settingRepository;
            _context = context;
        }
        //when creating new setting: add "image" to the end if the parameter value is a picture, if it is a number "count"
        public  IActionResult Index(int page = 1)
        {

            return View( _settingService.GetPaginateSettings(page));
        }
        public async Task CreatSetting()
        {
            foreach (var stng in Enum.GetValues(typeof(SettingKeysEnum)))
            {
                if (!await _settingRepository.IsExist(s=>s.Key== stng.ToString()))
                {
                    await _settingRepository.CreateAsync(new Setting { Key = stng.ToString(),Value="1" });
                }
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var setting = await _settingRepository.GetSingleAsync(x => x.Id == id);
            int num;
            if(int.TryParse(setting.Value, out num))
            {
            setting.NumValue = num;

            }
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Setting setting)
        {
            if (setting.NumValue ==0 && setting.Value is null) return View(setting);

            //   var oldSetting = await _settingRepository.GetSingleAsync(x => x.Id == setting.Id);
            var oldSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == setting.Id);
            if (oldSetting is null) { return View("error","home"); }
            setting.Value = setting.NumValue.ToString();
            if (oldSetting.Key.Contains("image"))
            {
                if (setting.ImageFile != null)
                {
                    _fileService.DeleteAsync(_env.WebRootPath, "/uploads/settings/", oldSetting.Value);
                    oldSetting.Value = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/settings/", setting.ImageFile);
                }
                else
                {
                    oldSetting.Value = oldSetting.Value;
                }
            }
            else
            {
                oldSetting.Value = setting.Value;
            }

            //await _settingRepository.Save();
            // _settingService.UpdateSetting(setting);
            _context.Settings.Update(oldSetting);
             _context.SaveChanges();

            return RedirectToAction("index", "setting");
        }
    }
}
