using Kafedra.Application.DTOs.AccountDTOs;
using Kafedra.Application.Interfaces.Services.AccountServices;
using Kafedra.Domain.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Concretes.Services
{
    public class AccountService : IAccountService
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _singInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public async Task<AppUser> Login(LoginDto loginDto)
        {
            var appUser = await _userManager.FindByNameAsync(loginDto.UserName);

            if (appUser == null)
                throw new Exception("Not found User");
            //todo change error

            var result = await _singInManager.PasswordSignInAsync(appUser, loginDto.Password, false, false);

            if (!result.Succeeded)
                throw new Exception("Not found User");

            return appUser;
        }

    }
}
