using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
