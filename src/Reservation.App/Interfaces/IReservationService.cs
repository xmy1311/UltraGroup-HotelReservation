using Reservation.App.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationResponseDto> CreateReservationAsync(ReservationRequestDto reservationRequestDto);
        Task<ReservationResponseDto?> GetReservationByIdAsync(Guid reservationId);
        Task<IEnumerable<ReservationResponseDto>> GetAllReservationsAsync();
        Task CancelReservationAsync(Guid id);
        Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomAsync(string city, DateTime checkIn, DateTime checkOut, 
                                                                  int numberOfGuests);
    }
}
