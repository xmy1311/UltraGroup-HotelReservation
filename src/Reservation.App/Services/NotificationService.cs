using Microsoft.Extensions.Logging;
using Reservation.App.Interfaces;


namespace Reservation.App.Services
    {
        public class NotificationService(ILogger<NotificationService> logger)
            : INotificationService
        {
            private readonly ILogger<NotificationService> _logger = logger;

        public Task SendReservationConfirmationAsync(Guid reservationId, string guestEmail, string guestName, string agentEmail)
        {
          
                _logger.LogInformation(
                    """    
                Reservation confirmation email sent successfully.
                ReservationId: {ReservationId}
                Guest:
                Name: {GuestName}
                Email: {GuestEmail}
                Agent:
                Email: {AgentEmail}
                """,reservationId,guestName,guestEmail, agentEmail);

                return Task.CompletedTask;
            }
    }
    }

