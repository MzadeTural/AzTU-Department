using Kafedra.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class Curriculum:BaseEntity
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }
    }
}
