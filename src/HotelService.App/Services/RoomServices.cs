using HotelService.App.DTOs;
using HotelService.App.Interfaces;
using HotelService.Domain.Entities;
using HotelService.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace HotelService.App.Services
{
    public class RoomServices(IRoomRepository roomRepository, ILogger<RoomServices> logger) : IRoomServices

    {
        private readonly IRoomRepository _roomRepository = roomRepository;
        private readonly ILogger<RoomServices> _logger = logger;

        public async Task<RoomResponseDto> CreateRoomAsync(RoomRequestDto roomDto)
        {
            var newRoom = new RoomEntity(roomDto.HotelId, 
                                   roomDto.Number, 
                                   roomDto.Type, 
                                   roomDto.Price, 
                                   roomDto.Taxes,
                                   roomDto.Location,
                                   roomDto.Capacity);

            await _roomRepository.AddAsync(newRoom);

            _logger.LogInformation("Room created successfully with ID: {RoomId}", newRoom.Id);

            return MapToResponse(newRoom);
        }

        public Task<bool> DisableAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnableAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomResponseDto>> GetByHotelAsync(Guid hotelId)
        {
            var rooms = await _roomRepository.GetByHotelAsync(hotelId);

            return rooms.Select(MapToResponse);

        }

        public async Task<RoomResponseDto?> GetByIdAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id)
                       ?? throw new KeyNotFoundException($"Room with ID {id} not found.");

            return MapToResponse(room);
            
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRoomByCityAsync(string city, int capacity)
        {
           var rooms= await _roomRepository.GetRoomsByCityAsync(city, capacity);

            return rooms.Select(MapToResponse);
        }

        public async Task<bool> UpdateAsync(Guid id,RoomRequestDto roomDto)
        {
           var room = _roomRepository.GetByIdAsync(id).Result
                      ?? throw new KeyNotFoundException($"Room with ID {id} not found.");
            room.Update(roomDto.Number,
                        roomDto.Type,
                        roomDto.Price,
                        roomDto.Taxes,
                        roomDto.Location,
                        roomDto.Capacity);

            _roomRepository.UpdateAsync(room).Wait();

            _logger.LogInformation("Room updated successfully with ID: {RoomId}", room.Id);


            return true;
        }

        private static RoomResponseDto MapToResponse(RoomEntity roomEntity)
        {
            return new RoomResponseDto
            {
                Id = roomEntity.Id,
                HotelId = roomEntity.HotelId,
                Number = roomEntity.Number,
                Type = roomEntity.Type,
                Price = roomEntity.Price,
                Taxes = roomEntity.Taxes,
                Location = roomEntity.Location,
                Capacity = roomEntity.Capacity,
                IsEnabled = roomEntity.IsEnabled,
                CreatedAt = roomEntity.CreatedAt
            };
        }

    }
}
