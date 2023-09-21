using AutoMapper;
using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Application.Utilities.Enums;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Kafedra.Persistence.Concretes.Services;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Kafedra.Business.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly LayoutServices _settings;
       
        private IWebHostEnvironment _env;
        private readonly IFileService _fileService;

        public EventService(LayoutServices settings, IMapper mapper, IEventRepository eventRepository, IFileService fileService,  IWebHostEnvironment env)
        {
            _settings = settings;
            _mapper = mapper;
            _eventRepository = eventRepository;
            _fileService = fileService;
           
            _env = env;
        }

        public async Task CreateEventAsync(EventCreateDto createDto, string? time = null)
        {

            var timeArr = time.Split("-");
            string format = "dd/MM/yyyy HH:mm";
            DateTime startTime = DateTime.ParseExact(timeArr[0].Trim(), format, CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(timeArr[1].Trim(), format, CultureInfo.InvariantCulture);


            string fileName = await _fileService.UploadAsync(_env.WebRootPath + "/uploads/events/", createDto.ImageFile);

            var newEvent = _mapper.Map<Event>(createDto);
            newEvent.Image = fileName;
            newEvent.StartTime = startTime;
            newEvent.EndTime = endTime;
            await _eventRepository.CreateAsync(newEvent);

            await _eventRepository.SaveAysnc();
        }

        public PagenatedListDto<Event> GetPaginateEvents(int page = 1)
        {
            Dictionary<string, string> settings = _settings.GetSetting();
            int pageSize = Convert.ToInt32(settings[SettingKeysEnum.Event_PageSize_count.ToString()]);
            var events = _eventRepository.GetAll();   
            return PagenatedListDto<Event>.Save(events, page, pageSize);

        }

        public async void Update(EventEditDto eventEditDto, string fileName, string? time = null)
        {
            var eventItem = await _eventRepository.GetSingleAsync(x => x.Id == eventEditDto.Id);
             
            var timeArr = time.Split("-");
            string format = "dd/MM/yyyy HH:mm";
            DateTime startTime = DateTime.ParseExact(timeArr[0].Trim(), format, CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(timeArr[1].Trim(), format, CultureInfo.InvariantCulture);
           eventItem =  _mapper.Map(eventEditDto, eventItem);

            eventItem.Image = fileName;
            eventItem.StartTime = startTime;
            eventItem.EndTime = endTime;
            _eventRepository.Update(eventItem);
            _eventRepository.Save();

         
        }

        public async Task<List<Event>> GetAllEvents()
        {
            var events =  _eventRepository.GetAll(i => !i.IsDeleted).OrderByDescending(e=>e.Id).Take(5).ToListAsync();
            return await events;
        }

        public async Task<List<Event>> LoadMore(int page)
        {
            int count = 5;
            var model =await  _eventRepository.GetAll(i => !i.IsDeleted)
                                .OrderByDescending(e => e.Id)
                                .Skip(page)
                                .Take(count)                              
                                .ToListAsync();
            return  model;
        }

        public async Task<Event> Detail(int id)
        {
            return await _eventRepository.GetByIdAsync(id);
        }

        public async Task ChangeStatus(int id)
        {
            var entity = await _eventRepository.GetByIdAsync(id);

            if (entity is null) return ;

            if (_eventRepository.Active(entity))
                entity.IsDeleted = true;
            else
                entity.IsDeleted = false;
          await  _eventRepository.SaveAysnc();
        }
    }
}
