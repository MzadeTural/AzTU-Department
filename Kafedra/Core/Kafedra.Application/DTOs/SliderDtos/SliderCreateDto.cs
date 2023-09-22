using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs.SliderDtos
{
    public class SliderCreateDto
    {
        public IFormFile ImageUrl { get; set; }
    }
}
