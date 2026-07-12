using System;
using System.Collections.Generic;
using System.Text;
using UltraGroup.Common.Enums;

namespace Reservation.App.DTOs
{
    public class ReservationResponseDto
    {
        public Guid ReservationId { get; set; }
        public Guid HotelId { get; set; }

        public Guid RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NumberOfGuests { get; set; }

        public string EmergencyContactName { get; set; } = string.Empty;

        public string EmergencyContactPhone { get; set; } = string.Empty;

        public ReservationStatus Status { get; set; }

        public List<GuestDto> Guests { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
