using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.AnnouncementDTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Interfaces
{
    public interface IAnnouncementService
    {
      
        public Task<List<Announcement>> GetAllAnnouncements();
        public PagenatedListDto<Announcement> GetAnnouncementsPagination(int page);
        public Task CreateAnnouncementAsync(CreateAnnouncementsDto createDto);
        public Task<AnnouncementUpdateDto> GetByIdAsync(int id);
        public void Update (AnnouncementUpdateDto updateDto,int id);
    }
}
