using Kafedra.Application.DTOs.Users;
using Kafedra.Domain.Enums;
using Kafedra.Domain.Identities;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly KafedraContext _context;
        public UserController(UserManager<AppUser> userManager, KafedraContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {

            var usersWithRoles = _context.AppUsers.Select(user => new UsersGetDto
            {
                User = user,
                Roles = _context.UserRoles
                 .Where(ur => ur.UserId == user.Id)
                 .Join(_context.Roles, ur => ur.RoleId, role => role.Id, (ur, role) => role.Name)
                 .ToList()
            }).ToList();
            return View(usersWithRoles);
        }
    }
}
