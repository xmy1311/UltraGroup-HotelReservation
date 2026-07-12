using System;
using System.Collections.Generic;
using System.Text;
using HotelService.Domain.Entities;

namespace HotelService.Domain.Interfaces
{
    public interface IRoomRepository
    {

        Task AddAsync(RoomEntity room);

        Task<RoomEntity?> GetByIdAsync(Guid id);

        Task<IEnumerable<RoomEntity>> GetByHotelAsync(Guid hotelId);

        Task UpdateAsync(RoomEntity room);

        Task<IEnumerable<RoomEntity>> GetRoomsByCityAsync(string city,int capacity);

    }
}
