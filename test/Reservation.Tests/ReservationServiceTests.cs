using Microsoft.Extensions.Logging;
using Moq;
using Reservation.App.Interfaces;
using Reservation.App.Services;
using Reservation.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Reservation.Tests
{
    public class ReservationServiceTests
    {
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly Mock<INotificationService> _notificationServiceMock;
        private readonly Mock<IHotelClient> _hotelClientMock;
        private readonly Mock<ILogger<ReservationService>> _loggerMock;

        private readonly ReservationService _service;

        public ReservationServiceTests()
        {
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _notificationServiceMock = new Mock<INotificationService>();
            _hotelClientMock = new Mock<IHotelClient>();
            _loggerMock = new Mock<ILogger<ReservationService>>();

            _service = new ReservationService(
                _reservationRepositoryMock.Object,
                _notificationServiceMock.Object,
                _hotelClientMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task CreateReservationAsync_NullRequest_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _service.CreateReservationAsync(null!));
        }
    }
}