using Kafedra.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class CurriculumSubject : BaseEntity
    {

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

    }
}
