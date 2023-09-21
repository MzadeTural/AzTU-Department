using Kafedra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Interfaces
{
    public interface IPartnerService
    {
        public Task<List<Partners>> GetAllPartners();
    }
}
