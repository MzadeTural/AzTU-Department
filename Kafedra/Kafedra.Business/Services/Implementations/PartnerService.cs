using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Implementations
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public Task<List<Partners>> GetAllPartners()
        {
           var partners = _partnerRepository.GetAll(p=>!p.IsDeleted).ToListAsync();
            return partners;
        }
    }
}
