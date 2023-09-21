using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Detail()
        {
            return View();
        }
    }
}
