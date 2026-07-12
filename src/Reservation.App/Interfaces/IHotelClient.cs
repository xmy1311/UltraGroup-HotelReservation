using Reservation.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.Interfaces
{
    public interface IHotelClient
    {
        Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomsAsync(string city, int capacity);
    }
}
