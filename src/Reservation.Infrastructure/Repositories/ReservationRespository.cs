using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces;
using Reservation.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using UltraGroup.Common.Enums;

namespace Reservation.Infrastructure.Repositories
{
    public class ReservationRespository(ReservationDbContext reservationDbContext) : IReservationRepository
    {
        private readonly ReservationDbContext _reservationDbContext = reservationDbContext;

        public async Task<ReservationEntity> CreateReservationAsync(ReservationEntity reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            await _reservationDbContext.Reservations.AddAsync(reservation);
            await _reservationDbContext.SaveChangesAsync();

            return reservation;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
           return _reservationDbContext.Reservations.AnyAsync(r => r.Id == id);
        }

        public async Task<ReservationEntity?> GetReservationByIdAsync(Guid reservationId)
        {
            return await _reservationDbContext.Reservations
                         .Include(r => r.Guests).FirstOrDefaultAsync(r => r.Id == reservationId);
        }

        public async Task<IEnumerable<ReservationEntity>> GetAllReservationsAsync()
        {
            return await _reservationDbContext.Reservations
                         .Include(r => r.Guests).ToListAsync();
        }

        public async Task<bool> IsRoomAvailableAsync(Guid roomId,
                                               DateTime checkIn,
                                               DateTime checkOut)
        {

            var validateReservation = await _reservationDbContext.Reservations
                .AnyAsync(r =>
                          r.RoomId == roomId &&
                          r.Status != ReservationStatus.Cancelled &&
                          checkIn < r.CheckOut && checkOut > r.CheckIn);

            return !validateReservation;

        }

        public async Task<ReservationEntity> UpdateReservationAsync(ReservationEntity reservationEntity)
        {
            _reservationDbContext.Reservations.Update(reservationEntity);
            await _reservationDbContext.SaveChangesAsync();

            return reservationEntity;
        }

    }
}
