using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.DTOs
{
    public class RoomAvailabilityFilterDto
    {
        public string City { get; set; } = string.Empty;
        public int Capacity { get; set; }


    }
}
