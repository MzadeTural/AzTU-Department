using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly KafedraContext _context;

        public FooterViewComponent(KafedraContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
            return View(await Task.FromResult(setting));
        }
    }
}
