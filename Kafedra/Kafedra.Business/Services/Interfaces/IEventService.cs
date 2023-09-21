using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Interfaces
{
    public interface IEventService
    {
        public PagenatedListDto<Event> GetPaginateEvents(int page = 1);
        public Task<List<Event>> GetAllEvents();
        public  Task CreateEventAsync(EventCreateDto createDto, string? time = null);
        public void Update(EventEditDto entity, string fileName, string? time = null );
        public Task<List<Event>> LoadMore(int page);
        public Task<Event> Detail(int id);
        public Task ChangeStatus(int id);
       
           

    }
}
