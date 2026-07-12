using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.DTOs
{
    public class AvailableRoomFilterDto
    {
        public string City { get; set; } = string.Empty;

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NumberOfGuests { get; set; }
    }
}
