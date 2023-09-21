using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
