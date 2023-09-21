using Kafedra.Application.DTOs.AccountDTOs;
using Kafedra.Application.ViewModel.Account;
using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Kafedra.Domain.Identities;
using Kafedra.Infrastructure.Services.EmailServices;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using MimeKit;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol;
using System;
using static Kafedra.Domain.Identities.AppUser;

namespace Kafedra.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly KafedraContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<MailSettings> _mailSettings;
        private readonly IWebHostEnvironment _env;
        //testing number 1-5 -3
        public AccountController(KafedraContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<MailSettings> mailSettings, IWebHostEnvironment env)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mailSettings = mailSettings;
            _env = env;
            //asjdnhfbsd xncvsdja  bbsdcb klahebckab ealhwal
            //salam qaqa netetr
            // deb7fcf7d04cf081f44000abc2e449549571606f
        }
        public ActionResult Login(int id)
        {
            return View();
        }
        public ActionResult SuccessRegistration()
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Email və ya şifrə yanlışdır");
               
                return View(login);
            }
           
            if (!user.IsActivated)
            {
                ModelState.AddModelError(string.Empty, "Zəhmət olmasa,hesabiniz aktivləşdirin.Email'nizi nəzərdən keçirin");
                return View(login);
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email və ya şifrə yanlışdır");
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: AccountController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);

            AppUser newUser = new AppUser
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                FromAztu = register.FromAztu,
                UserName = register.UserName
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            var pathToFile = _env.WebRootPath
                           + Path.DirectorySeparatorChar.ToString()
                           + "Templates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "EmailTemplate"
                           + Path.DirectorySeparatorChar.ToString()
                           + "SendEmail.html";

            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }


            string? confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { email = newUser.Email, token }, HttpContext.Request.Scheme, Request.Host.ToString());

            string messageBody = string.Format(builder.HtmlBody, confirmationLink, register.UserName);
           await _userManager.IsEmailConfirmedAsync(newUser);
           Email.SendMail(register.Email, "Email Confirmation", messageBody, _mailSettings.Value.Email, _mailSettings.Value.Password);

           
            await _userManager.AddToRoleAsync(newUser, UserRoles.Student.ToString());
            return RedirectToAction(nameof(SuccessRegistration));



            //   await _userManager.AddToRoleAsync(newUser, UserRoles.Member.ToString());



        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string? token, string? email)
        {
            ViewBag.Token = token;
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);

            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email","User Not Found" );
                return View();
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);

            if (!resetPassResult.Succeeded)
            {

                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetPasswordModel);
            }
            //   return RedirectToAction("Index", "Home");
            //var response = new { success = true, message = "Email sent successfully!" };
            //return Json(response);
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPassword)
        {
            if (!ModelState.IsValid) return View(forgotPassword);
        
            AppUser user = await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "User Not Found");
               
                return View() ;
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var confirmationLink = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

            string pathToFile = Path.Combine(_env.WebRootPath, "Templates", "EmailTemplate", "ChangePassword.html");
           

            Email.SendMail(user.Email,"Reset Password", GenerateMessageBody(pathToFile, confirmationLink), _mailSettings.Value.Email, _mailSettings.Value.Password);
             var response = new { success = true, message = "Email sent successfully!" };
          
             return Json(response);         
           // return View(response);

        }
        public string GenerateMessageBody(string filePath, params object[] args)
        {
           
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(filePath))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }
            
            string messageBody = string.Format(builder.HtmlBody,args) ;
            return messageBody;
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public async Task<ActionResult> ConfirmEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                user.IsActivated = true;
                await _context.SaveChangesAsync();
            }
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }
        public async Task<ActionResult> logOut(int id)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }

        // GET: AccountController/Edit/5

    }
}