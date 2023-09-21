using AutoMapper;
using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.AnnouncementDTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper _mapper;
      

        public AnnouncementService(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
           
        }

        public async Task CreateAnnouncementAsync(CreateAnnouncementsDto createDto)
        {
            var newAnnouncement = _mapper.Map<Announcement>(createDto);
           await _announcementRepository.CreateAsync(newAnnouncement);
            await _announcementRepository.SaveAysnc();
        }

        public async Task<List<Announcement>> GetAllAnnouncements()
        {
            var announcements =   _announcementRepository.GetAll(i => !i.IsDeleted).OrderByDescending(e => e.Id).Take(5).ToListAsync();
            return await announcements;
        }

        public  PagenatedListDto<Announcement> GetAnnouncementsPagination(int page)
        {
            var announcements =  _announcementRepository.GetAll();        
            return PagenatedListDto<Announcement>.Save(announcements, page, 4);
        }

        public async Task<AnnouncementUpdateDto> GetByIdAsync(int id)
        {
        var announcement =  await _announcementRepository.GetByIdAsync(id);
           return   _mapper.Map<AnnouncementUpdateDto>(announcement);
        }

        public async void Update(AnnouncementUpdateDto updateDto,int id)
        {
            var announcementItem = await _announcementRepository.GetByIdAsync(id);
            announcementItem = _mapper.Map(updateDto, announcementItem);

            _announcementRepository.Update(announcementItem);
           
            await _announcementRepository.SaveAysnc();
        }
    }
}
