using System;
using System.Collections.Generic;
using System.Text;
using UltraGroup.Common.Enums;

namespace Reservation.App.DTOs
{
    public class GuestDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }= string.Empty;
        public string Email { get; set; }=string.Empty;

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
