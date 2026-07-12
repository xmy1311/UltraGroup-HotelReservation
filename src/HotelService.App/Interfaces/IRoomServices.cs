using HotelService.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.Interfaces
{
    public interface IRoomServices
    {
   
        Task<RoomResponseDto> CreateRoomAsync(RoomRequestDto roomDto);

        Task<RoomResponseDto?> GetByIdAsync(Guid id);

        Task<IEnumerable<RoomResponseDto>> GetByHotelAsync(Guid hotelId);

        Task<bool>  UpdateAsync(Guid id,RoomRequestDto roomDto);

        Task<bool> DisableAsync(Guid id);

        Task<bool> EnableAsync(Guid id);

        Task<IEnumerable<RoomResponseDto>> GetRoomByCityAsync(string city, int capacity);


    }
}
