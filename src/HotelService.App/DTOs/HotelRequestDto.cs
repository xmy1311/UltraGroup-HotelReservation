using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.DTOs
{
    public class HotelRequestDto
    {
        public string HotelName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

  
}
