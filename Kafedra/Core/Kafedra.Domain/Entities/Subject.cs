using Kafedra.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class Subject:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserSubject> UserSubjects { get; set; }
        public ICollection<SubjectQualification> SubjectQualifications { get; set; }
        public int CurriculumId { get; set; }
    }
}
