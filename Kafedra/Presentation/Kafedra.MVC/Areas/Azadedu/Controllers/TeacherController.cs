using Kafedra.Application.DTOs.Teacher;
using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Kafedra.Domain.Identities;
using Kafedra.Infrastructure.Services.EmailServices;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;

namespace Kafedra.MVC.Areas.Azadedu.Controllers
{
    [Area("Azadedu")]
    public class TeacherController : Controller
    {
        private readonly KafedraContext _context;
        private UserManager<AppUser> _userManager;

        public TeacherController(KafedraContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userss = await _userManager.GetUsersInRoleAsync(UserRoles.Teacher.ToString());


            var usersWitSpesifichRoles = userss.Select(user => new TeacherGetDto
            {
                User = user,
                Roles = _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Join(_context.Roles, ur => ur.RoleId, role => role.Id, (ur, role) => role.Name)
                .ToList()
            }).ToList();

            return View(usersWitSpesifichRoles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateDto createDto)
        {
            if (!ModelState.IsValid) return View(createDto);

            AppUser newUser = new AppUser
            {
                Name = createDto.Name,
                Surname = createDto.Surname,
                Email = createDto.Email,             
                UserName = createDto.UserName

            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, createDto.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(createDto);
            }
           


            await _userManager.AddToRoleAsync(newUser, UserRoles.Teacher.ToString());

            return View();
        }
    }
}
