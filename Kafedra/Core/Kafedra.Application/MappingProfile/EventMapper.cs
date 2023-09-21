using AutoMapper;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Domain.Entities;

namespace Kafedra.Application.MappingProfile
{
    public class EventMapper :Profile
    {
        public EventMapper()
        {
            CreateMap<EventCreateDto, Event>().ReverseMap();
            CreateMap<Event,EventEditDto>().ReverseMap().ForMember(ev => ev.Image, opt => opt.Ignore());

        }
    }
}
