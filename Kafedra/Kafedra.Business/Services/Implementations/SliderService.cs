using Kafedra.Application.DTOs;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Infrastructure.Hubs;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IHubContext<RealTimeHub> _hubContext;


        public SliderService(ISliderRepository sliderRepository, IHubContext<RealTimeHub> hubContext)
        {
            _sliderRepository = sliderRepository;
            _hubContext = hubContext;
        }

        public async Task ChangeStatus(int id)
        {
            var slide = await _sliderRepository.GetByIdAsync(id);

            if (slide is null) return;

            if (_sliderRepository.Active(slide))
                slide.IsDeleted = true;
            else
                slide.IsDeleted = false;
            await _sliderRepository.SaveAysnc();
        }

        public async Task<List<Slider>> GetAllSlides()
        {
            var sliders = _sliderRepository.GetAll(i => !i.IsDeleted).ToListAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveUpdatedData", sliders);
            return await sliders;
        }

        public PagenatedListDto<Slider> GetPaginateSliders(int page = 1)
        {
            var sliders = _sliderRepository.GetAll();
            return PagenatedListDto<Slider>.Save(sliders, page, 5);
        }
    }
}
