
using Kafedra.Application.Utilities.File;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Application.ViewModel.SliderVM;
using Kafedra.Business.Services.Implementations;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class SliderController : Controller
    {
        private string _errorMessage;
        private IWebHostEnvironment _env;
        private readonly KafedraContext _context;
       
        private readonly ISliderService _sliderService;
        public SliderController(IWebHostEnvironment env, ISliderService sliderService, KafedraContext context)
        {

            _env = env;
            _sliderService = sliderService;
            _context = context;
        }
        public  IActionResult Index()
        {

            //return View(_sliderService.GetPaginateSliders(1));
            return View( _sliderService.GetPaginateSliders());
            
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeStatus(int id)
        {
            try
            {
              await  _sliderService.ChangeStatus(id);
                var slide = await _context.Sliders.FirstOrDefaultAsync(e => e.Id == id);
                //  TempData["Success"] = "adads";
                return Ok(slide);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json("Error 404");
            }
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateSliderVM sliderVM)
        //{
        //    if (!ModelState.IsValid) return View(sliderVM);
        //    if (sliderVM is null) return View();
        //    if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(sliderVM);
        //    if (!CheckImageValid(sliderVM))
        //    {
        //        ModelState.AddModelError("Photo", _errorMessage);
        //        return View(sliderVM);
        //    }
        //    string fileName = await sliderVM.Photo.SaveFile(_env.WebRootPath, "assets", "img");
        //    await _sliderRepository.Create(new()
        //    {
        //        Image = fileName,
        //    });

        //    await _sliderRepository.Save();
        //    return RedirectToAction(nameof(Index));
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //       var slider=  await _sliderRepository.GetByIdAsync(id);
        //       Helper.RemoveFile(_env.WebRootPath,"img",slider.Image);
        //        await _sliderRepository.DeleteAsync(id);
        //        await _sliderRepository.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Json("Error 404");
        //    }
        //}

        private bool CheckImageValid(CreateSliderVM eventVM)
        {

            if (!eventVM.Photo.CheckFileType("image/"))
            {
                _errorMessage = $"{eventVM.Photo.FileName}-faylin novu Ferqlidir!";
                return false;
            }
            if (!eventVM.Photo.CheckFileSize(300))
            {
                _errorMessage = $"{eventVM.Photo.FileName}- faylin olcusu boyukdur!";
                return false;
            }

            return true;
        }
    }
}
