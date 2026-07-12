using System;
using System.Collections.Generic;
using System.Text;
using UltraGroup.Common.Enums;

namespace Reservation.App.DTOs
{
    public class AvailableRoomDto
    {
        public Guid RoomId { get; set; }

        public Guid HotelId { get; set; }

        public string Number { get; set; } = string.Empty;

        public RoomType Type { get; set; }

        public decimal Price { get; set; }
        public string HotelName { get; set; }= string.Empty;

        public string City { get; set; }=string.Empty;
        public decimal Taxes { get; set; }

        public string Location { get; set; } = string.Empty;

    }
}
