using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.App.Interfaces
{
    public  interface INotificationService
    {
        Task SendReservationConfirmationAsync(
            Guid reservationId, string guestEmail,
            string guestName,
            string agentEmail
            );
    }
}
