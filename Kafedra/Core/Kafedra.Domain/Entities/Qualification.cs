using Kafedra.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class Qualification:BaseEntity
    {     
        public string Name { get; set; }
        public ICollection<SubjectQualification> UserSubjects { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
