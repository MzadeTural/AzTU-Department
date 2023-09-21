using Kafedra.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs.Teacher
{
    public class TeacherGetDto
    {
        public AppUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
