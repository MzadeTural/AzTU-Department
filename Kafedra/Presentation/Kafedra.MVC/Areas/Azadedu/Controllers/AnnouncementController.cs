using AutoMapper;
using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.AnnouncementDTOs;

using Kafedra.Application.ViewModel.AnnouncementVM;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly KafedraContext _context;
        private readonly IMapper _mapper;
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementController(IAnnouncementService announcementService, KafedraContext context, IMapper mapper, IAnnouncementRepository announcementRepository)
        {
            _announcementService = announcementService;
            _context = context;
            _mapper = mapper;
            _announcementRepository = announcementRepository;
        }

        // GET: EventController
        public IActionResult Index(int page = 1)
        {

            return View(_announcementService.GetAnnouncementsPagination(page));

        }

        // GET: EventController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

         //  POST: EventController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAnnouncementsDto CreateDto)
        {
            if (!ModelState.IsValid)
            {         
                    return View(CreateDto);
                }
           await _announcementService.CreateAnnouncementAsync(CreateDto);

            return RedirectToAction (nameof(Index));
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            return View(await _announcementService.GetByIdAsync(id));

        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AnnouncementUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {       
                    return View(updateDto);
                }

                var announcementItem = await _announcementRepository.GetByIdAsync(id);
                announcementItem = _mapper.Map(updateDto, announcementItem);
                _announcementRepository.Update(announcementItem);
                await _announcementRepository.SaveAysnc();

                //  _announcementService.Update(updateDto, id);

            }
            catch
            {
                return Json("Error 404");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActivOrUnactiv(int id, int page)
        {
            try
            {
                var entity = await _context.Announcements.FirstOrDefaultAsync(a=>a.Id==id);
                if(entity is null) return RedirectToAction("index", new { page = page }); 
                if (entity.IsDeleted)
                {
                    entity.IsDeleted = false;
                }
                else
                {
                    entity.IsDeleted = true;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("index", new { page = page }); ;
            }
            catch
            {
                return Json("Error 404");
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //      await  _announcementsRepository.DeleteAsync(id);
        //        await _announcementsRepository.Save();
        //        return RedirectToAction("Announcement", "Index");


        //    }
        //    catch
        //    {
        //        return Json("Error 404");
        //    }
        //}

    }
 
}
