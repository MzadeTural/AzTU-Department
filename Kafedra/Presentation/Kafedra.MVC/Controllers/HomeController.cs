using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Business.Services.Interfaces;
using Kafedra.MVC.Models;
using Kafedra.Persistence.Contexts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kafedra.MVC.Controllers
{
    public class HomeController : Controller
    {

       
        private readonly ISliderService _sliderService;
        private readonly IEventService _eventService;
        private readonly IPartnerService _partnerService;
        private readonly IAnnouncementService _announcementService;

        public HomeController(ISliderService sliderService, IEventService eventService, IPartnerService partnerService, IAnnouncementService announcementService)
        {
            _sliderService = sliderService;
            _eventService = eventService;
            _partnerService = partnerService;
            _announcementService = announcementService;
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }
            public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM()
            {

                Sliders = await _sliderService.GetAllSlides(),
            Events = await _eventService.GetAllEvents(),
        
                Announcements = await _announcementService.GetAllAnnouncements(),
                Partners = await  _partnerService.GetAllPartners(),


            };
            return View(model);
        }
        

    }
}