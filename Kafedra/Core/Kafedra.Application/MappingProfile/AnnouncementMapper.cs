using AutoMapper;
using Kafedra.Application.DTOs.AnnouncementDTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.MappingProfile
{
    public class AnnouncementMapper:Profile
    {
        public AnnouncementMapper()
        {
            CreateMap<CreateAnnouncementsDto, Announcement>().ReverseMap();
            CreateMap<Announcement, AnnouncementUpdateDto>().ReverseMap();
        }
    }
}
