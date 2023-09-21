using Kafedra.Application.DTOs;
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

    }
}
