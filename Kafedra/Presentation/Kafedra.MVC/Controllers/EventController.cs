using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Application.ViewModel.Home;
using Kafedra.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Controllers
{
    public class EventController : Controller
    {
       
        private readonly IEventService _eventService;

        public EventController( IEventService eventService)
        {
          
            _eventService = eventService;
        }
        public async Task<IActionResult> Index()
        {
          
            ViewBag.Count=5;
            return View(await _eventService.GetAllEvents());
        } 
        public async Task<IActionResult> LoadMore(int page) {

          var events= await _eventService.LoadMore(page);
            return PartialView("_EventPartial", events);
        }
        public async Task<IActionResult> Detail(int id)
        {
           
            return View(await _eventService.Detail(id));
        }
    }
}
