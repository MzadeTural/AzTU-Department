using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
