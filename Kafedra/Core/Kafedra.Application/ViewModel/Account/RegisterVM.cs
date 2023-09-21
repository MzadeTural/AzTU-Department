using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.ViewModel.Account
{
    public class RegisterVM
    {
        public string Name { get; set; }   
        public string Surname { get; set; } 
        public string UserName { get; set; } 
        public string Email { get; set; }
        public bool FromAztu { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPasword { get; set; }
    }
}
