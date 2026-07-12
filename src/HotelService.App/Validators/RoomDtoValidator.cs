using FluentValidation;
using HotelService.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.Validators
{
    public class RoomDtoValidator : AbstractValidator<RoomRequestDto>
    {
        public RoomDtoValidator()
        {
        RuleFor(r=>r.HotelId)
            .NotEmpty()
            .WithMessage("HotelId is required.");


            RuleFor(r => r.Number)
            .NotEmpty()
            .MaximumLength(50);

            RuleFor(r => r.Type)
                .IsInEnum();

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(r => r.Taxes)
               .GreaterThanOrEqualTo(0);

            RuleFor(r => r.Location)
                .NotEmpty()
                .MaximumLength(100);

        }
    }
}
