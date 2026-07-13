using FluentValidation;
using Reservation.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.Validators
{
    public class GuestDtoValidator : AbstractValidator<GuestDto>
    {
        public GuestDtoValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty();

            RuleFor(r => r.DocumentNumber)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(r => r.DocumentType)
               .NotEmpty(); 
             

             RuleFor(r => r.FirstName)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);

            RuleFor(r => r.LastName)
                .NotEmpty();

            RuleFor(r => r.PhoneNumber)
              .NotEmpty();

        }
    }
}
