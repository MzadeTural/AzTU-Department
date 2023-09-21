using Kafedra.Application.DTOs.EventDTOs;

using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories;
using Kafedra.Persistence.Repositories.Implementations;
using Kafedra.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Repositories.Implementations
{
    public class EventRepository : Repository<Event>,IEventRepository
    {
        public EventRepository(KafedraContext context) : base(context)
        {
        }
    }
}
