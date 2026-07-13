using FluentValidation;
using Reservation.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.Validators
{
    public class ReservationDtoValidator : AbstractValidator<ReservationRequestDto>
    {
        public ReservationDtoValidator()
        {
            RuleFor(r => r.CheckIn)
                .NotEmpty();

            RuleFor(r => r.CheckOut)
                .NotEmpty();

            RuleFor(r => r.EmergencyContactPhone)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(10);

             RuleFor(r => r.EmergencyContactName)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);

            RuleFor(r => r.NumberOfGuests)
                .NotEmpty();

        }
    }
}
