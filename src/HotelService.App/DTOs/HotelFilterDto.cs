using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.DTOs
{
    public class HotelFilterDto
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public bool? IsEnabled { get; set; }

    }
}
