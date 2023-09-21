using Kafedra.Application.DTOs.AccountDTOs;
using Kafedra.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Interfaces.Services.AccountServices
{
    public interface IAccountService
    {
       
        Task<AppUser> Login(LoginDto loginDto);
    }
}
