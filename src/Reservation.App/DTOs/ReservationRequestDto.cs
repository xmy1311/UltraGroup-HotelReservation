using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.DTOs
{
    public class ReservationRequestDto
    {
        public Guid HotelId { get; set; }

        public Guid RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NumberOfGuests { get; set; }

        public string EmergencyContactName { get; set; }= string.Empty;

        public string EmergencyContactPhone { get; set; } = string.Empty;

        public List<GuestDto> Guests { get; set; } = [];

    }
}
