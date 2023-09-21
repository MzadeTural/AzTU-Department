using Kafedra.Application.DTOs;
using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class SubjectController : Controller
    {

        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public IActionResult Index(int page = 1)
        {
            var subjetcs = _subjectRepository.GetAll(x => x.IsDeleted == false);
            ViewBag.PageSize = 8;
            return View(PagenatedListDto<Subject>.Save(subjetcs, page, 8));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

       


    }
}
