using Kafedra.Application.DTOs.DashboardDTOs;
using Kafedra.Application.Utilities.Enums;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Concretes.Services;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Areas.Manage.Controllers
{
    [Area("Azadedu")]
    public class DashboardController : Controller
    {
        private readonly KafedraContext _context;
        private readonly LayoutServices _settings;

        public DashboardController(KafedraContext context, LayoutServices settings)
        {
            _context = context;
            _settings = settings;
        }

        public IActionResult Index()
        {
            var dashboardDTO=new DashboardListDTO()
            {
                AztuUserCount = _context.AppUsers.Where(u=>u.FromAztu & u.IsActivated).Count(),
                AllUserCount = _context.AppUsers.ToList().Count(),
                InActiveUserCount = _context.AppUsers.Where(u=>!u.IsActivated).Count(),
               
        };
            
            return View(dashboardDTO);
        }
    }
}