using AutoMapper;
using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.EventDTOs;


using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Infrastructure.Hubs;
using Kafedra.Persistence.Concretes.Services;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using System.Globalization;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        private string _errorMessage;
        private readonly IEventService _eventService;
        private readonly IEventRepository _eventRepository;
        private readonly KafedraContext _context;


        public EventController(IWebHostEnvironment env, IMapper mapper, IEventService eventService, IFileService fileService, IEventRepository eventRepository, KafedraContext context)
        {
            _env = env;
            _mapper = mapper;
            _eventService = eventService;
            _fileService = fileService;
            _eventRepository = eventRepository;
            _context = context;
        }
        [HttpPost]

        public IActionResult Test()
        {
            return View();
        }


        public IActionResult Index(int page = 1)
        {


            return View(_eventService.GetPaginateEvents(page));
        }
        public IActionResult Create()
        {

            DateTime startTime = DateTime.UtcNow.AddHours(4);

            TempData["StartYear"] = startTime.Year;
            TempData["StartMonth"] = startTime.Month;
            TempData["StartDay"] = startTime.Day;

            TempData["StartHour"] = startTime.Hour;
            TempData["StartMin"] = startTime.Minute;



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateDto createDto, string? time = null)
        {
            if (!ModelState.IsValid)
                return View(createDto);
            bool checkImage = _fileService.CheckImageValid(createDto.ImageFile, 10485760, ref _errorMessage, "image/jpeg", "image/png");
            if (checkImage == false)
            {
                ModelState.AddModelError("ImageFile", _errorMessage);
                return View(createDto);
            }
            await _eventService.CreateEventAsync(createDto, time);
            return RedirectToAction("index");
        }



        public async Task<IActionResult> Edit(int id)
        {
            var item = await _eventRepository.GetSingleAsync(x => x.Id == id);

            DateTime startTime = DateTime.UtcNow.AddHours(4);
            DateTime selectStartTime = Convert.ToDateTime(item.StartTime);
            DateTime selectEndTime = Convert.ToDateTime(item.EndTime);
            TempData["StartYear"] = startTime.Year;
            TempData["StartMonth"] = startTime.Month;
            TempData["StartDay"] = startTime.Day;

            TempData["StartHour"] = startTime.Hour;
            TempData["StartMin"] = startTime.Minute;
            #region selectStartTime

            TempData["SelectStartYear"] = selectStartTime.Year;
            TempData["SelectStartMonth"] = selectStartTime.Month;
            TempData["SelectStartDay"] = selectStartTime.Day;

            TempData["SelectStartHour"] = selectStartTime.Hour;
            TempData["SelectStartMin"] = selectStartTime.Minute;

            #endregion

            #region endTime

            TempData["SelectEndYear"] = selectEndTime.Year;
            TempData["SelectEndMonth"] = selectEndTime.Month;
            TempData["SelectEndDay"] = selectEndTime.Day;

            TempData["SelectEndHour"] = selectEndTime.Hour;
            TempData["SelectEndMin"] = selectEndTime.Minute;

            #endregion
            if (item is null) return NotFound();
            var eventEditDto = _mapper.Map<EventEditDto>(item);

            return View(eventEditDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventEditDto eventEditDto, string? time = null)
        {
            var eventItem = await _eventRepository.GetSingleAsync(x => x.Id == eventEditDto.Id);
            if (eventItem == null) return NotFound();
            string fileName = eventItem.Image;

            if (eventEditDto.ImageFile != null)
            {
                _fileService.DeleteAsync(_env.WebRootPath, "/uploads/events/", eventItem.Image);
                bool checkImage = _fileService.CheckImageValid(eventEditDto.ImageFile, 10485760, ref _errorMessage, "image/jpeg", "image/png");
                if (checkImage == false)
                {
                    ModelState.AddModelError("ImageFile", _errorMessage);
                    return View(eventEditDto);
                }

                fileName = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/events/", eventEditDto.ImageFile);
            }
            _eventService.Update(eventEditDto, fileName, time);

            return RedirectToAction("index");
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id,int page =1)
        {
           await _eventService.ChangeStatus(id);
            await _eventRepository.SaveAysnc();
            
            var evnt = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
         //  TempData["Success"] = "adads";
            return Ok(evnt);

           return RedirectToAction("index", new { page = page }); ;
        }


        //public async Task<IActionResult> Remove(int id)
        //{
        //    var eventItem = await _eventRepository.GetByIdAsync(id);

        //    if (eventItem == null)
        //    {
        //        return NotFound();
        //    }
        //    Helper.RemoveFile(_env.WebRootPath, "img", eventItem.Image);

        //    await _eventRepository.DeleteAsync(id);

        //    await _eventRepository.Save();

        //    return RedirectToAction("index");
        //}

    }
}

