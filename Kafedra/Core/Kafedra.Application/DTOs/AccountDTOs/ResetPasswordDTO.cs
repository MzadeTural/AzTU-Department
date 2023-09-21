using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs.AccountDTOs
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required,MinLength(8, ErrorMessage = "Şifrənin minimum uzunluğu '8' olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parollar uyğun gəlmir.")]
        public string ConfirmPassword { get; set; }
    }
}
