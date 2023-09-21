using Kafedra.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class UserDissertation
    {
        public int Id { get; set; }
        public int DissertationId { get; set; }
        public Dissertation Dissertation { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

