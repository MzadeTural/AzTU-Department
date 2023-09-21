using Kafedra.Domain.Entities.Common;
using Kafedra.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class Syllabus:BaseEntity
    {
        public string Name { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
