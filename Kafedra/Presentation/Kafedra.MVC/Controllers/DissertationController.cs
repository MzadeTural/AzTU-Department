using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Controllers
{
    public class DissertationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
