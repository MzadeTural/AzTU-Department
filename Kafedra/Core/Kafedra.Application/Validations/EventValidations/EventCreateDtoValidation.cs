using FluentValidation;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Validations.EventValidations
{
    public class EventCreateDtoValidation : AbstractValidator<EventCreateDto>
    {

        public EventCreateDtoValidation()
        {
            RuleFor(x => x.Content)
                .NotNull().NotEmpty();
        }

    }
}
