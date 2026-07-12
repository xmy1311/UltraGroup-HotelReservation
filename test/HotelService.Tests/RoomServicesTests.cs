using HotelService.App.Services;
using HotelService.Domain.Entities;
using HotelService.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HotelService.Tests
{
    public class RoomServicesTests
    {
        private readonly Mock<IRoomRepository> _roomRepositoryMock;
        private readonly Mock<ILogger<RoomServices>> _loggerMock;

        private readonly RoomServices _service;

        public RoomServicesTests()
        {
            _roomRepositoryMock = new Mock<IRoomRepository>();
            _loggerMock = new Mock<ILogger<RoomServices>>();

            _service = new RoomServices(
                _roomRepositoryMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_NotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            _roomRepositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((RoomEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _service.GetByIdAsync(Guid.NewGuid()));
        }
    }
}