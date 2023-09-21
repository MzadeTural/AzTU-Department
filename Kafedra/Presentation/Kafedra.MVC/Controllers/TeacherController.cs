using Microsoft.AspNetCore.Mvc;

namespace Kafedra.MVC.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
