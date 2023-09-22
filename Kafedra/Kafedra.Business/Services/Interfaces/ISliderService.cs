using Kafedra.Application.DTOs;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Application.DTOs.SliderDtos;
using Kafedra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Interfaces
{
    public interface ISliderService
    {
        public Task<List<Slider>> GetAllSlides();
        public PagenatedListDto<Slider> GetPaginateSliders(int page = 1);
        public Task ChangeStatus(int id);
        public Task CreateSliderAsync(SliderCreateDto createDto);

    }
}
