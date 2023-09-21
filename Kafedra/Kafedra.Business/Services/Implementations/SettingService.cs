using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        private readonly KafedraContext _context;

        public SettingService(ISettingRepository settingRepository, IFileService fileService, IWebHostEnvironment env, KafedraContext context)
        {
            _settingRepository = settingRepository;
            _fileService = fileService;
            _env = env;
            _context = context;
        }



        public  PagenatedListDto<Setting> GetPaginateSettings(int page)
        {
            int pageSize = 8;
            var events = _settingRepository.GetAll();
            return  PagenatedListDto<Setting>.Save(events, page, pageSize);


           
        }

        public async void UpdateSetting(Setting setting)
        {
            var oldSetting = await _settingRepository.GetByIdAsync(setting.Id);
          //  var oldSetting = _context.Settings.FirstOrDefault(setting => setting.Id == setting.Id); 
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
          _settingRepository.Update(setting); 
            //_context.Settings.Update(setting);
           //_context.SaveChanges();
            _settingRepository.Save();
        }
    }
}
