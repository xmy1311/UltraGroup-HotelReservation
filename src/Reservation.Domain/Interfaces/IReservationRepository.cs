using Reservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<ReservationEntity> CreateReservationAsync(ReservationEntity reservation);

        Task<ReservationEntity?> GetReservationByIdAsync(Guid reservationId);

        Task<IEnumerable<ReservationEntity>> GetAllReservationsAsync();

        Task<ReservationEntity> UpdateReservationAsync(ReservationEntity reservation);

        Task<bool> ExistsAsync(Guid id);

        Task<bool> IsRoomAvailableAsync(Guid roomId,
                                               DateTime checkIn, 
                                               DateTime checkOut);


    }
}
