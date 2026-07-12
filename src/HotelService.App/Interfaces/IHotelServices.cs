using HotelService.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.App.Interfaces
{
    public interface IHotelServices
    {
        Task<HotelResponseDto> CreateHotelAsync(HotelRequestDto hotelRequestDto);
        Task <HotelResponseDto?> GetHotelByIdAsync(Guid id);
        Task<IEnumerable<HotelResponseDto>> GetAllHotelsAsync(HotelFilterDto hotelFilterDto);

        Task<HotelResponseDto> UpdateAsync(Guid id, HotelRequestDto hotelDto);
        Task DisabledAsync(Guid id);
        Task EnableAsync(Guid id);

        Task<IEnumerable<RoomResponseDto>> GetAvailableRoomsAsync(RoomAvailabilityFilterDto roomAvailabilityFilterDto);
    }
}
