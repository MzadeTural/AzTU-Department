using Kafedra.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Identities
{
    public class AppUser : IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public bool FromAztu { get; set; }
        public bool IsActivated { get; set; }

        public ICollection<UserDissertation> UserDissertations { get; set; }
        public ICollection<UserSubject> UserSubjects { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        //todo we will change here
        public ICollection<Syllabus> Syllabus { get; set; }
      
    }
}
