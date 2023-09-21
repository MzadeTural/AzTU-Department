using Kafedra.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class UserSubject
    {
        public int Id { get; set; }
        public int SubejectID { get; set; }
        public Subject Subject{ get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
