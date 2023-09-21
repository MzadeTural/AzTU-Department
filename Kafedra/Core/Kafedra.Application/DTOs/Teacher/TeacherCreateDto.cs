using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs.Teacher
{
    public class TeacherCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType("Email")]
        public string Email { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string PedagogicalActivity { get; set; }
        public string ScientificActivity { get; set; }
        public string PhoneNumber { get; set; }
        public string FatherName { get; set; }
    }
}
