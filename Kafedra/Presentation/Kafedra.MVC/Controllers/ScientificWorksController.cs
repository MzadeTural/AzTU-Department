using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Controllers
{
    public class ScientificWorksController : Controller
    {
        private KafedraContext _context;

        public ScientificWorksController(KafedraContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dissertations.Where(x=>!x.IsDeleted).OrderByDescending(x=>x.Id).ToListAsync());
        }
    }
}
