using FluentValidation;
using HotelService.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.Validators
{
    public class HotelDtoValidator : AbstractValidator<HotelRequestDto>
    {
        public HotelDtoValidator()
        {
        RuleFor(x => x.HotelName)
            .NotEmpty()
            .MaximumLength(150);
        

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(250);

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

        }
    }
}
