using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.SliderDtos;
using Kafedra.Application.Interfaces.Services.Interfaces;
using Kafedra.Business.Services.Interfaces;
using Kafedra.Domain.Entities;
using Kafedra.Infrastructure.Hubs;
using Kafedra.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IHubContext<RealTimeHub> _hubContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;


        public SliderService(ISliderRepository sliderRepository, IHubContext<RealTimeHub> hubContext, IFileService fileService, IWebHostEnvironment env)
        {
            _sliderRepository = sliderRepository;
            _hubContext = hubContext;
            _fileService = fileService;
            _env = env;
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

        public async Task CreateSliderAsync(SliderCreateDto createDto)
        {
            string path = Path.Combine(_env.WebRootPath, "uploads", "sliders");
            string FileName = await _fileService.CreateFileAsync(createDto.ImageUrl,path);
            var newSlider = new Slider();
            newSlider.Image = FileName;
          await  _sliderRepository.CreateAsync(newSlider);
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
