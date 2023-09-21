
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Repositories.Implementations
{
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(KafedraContext context) : base(context)
        {
        }
    }
}
