using HotelService.App.DTOs;
using HotelService.App.Interfaces;
using HotelService.Domain.Entities;
using HotelService.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace HotelService.App.Services
{
    public class HotelServices(IHotelRespository hotelRepository, ILogger<HotelServices> logger) : IHotelServices
    {
        private readonly IHotelRespository _hotelRepository = hotelRepository;

        private readonly ILogger<HotelServices> _logger = logger;

        public async Task<HotelResponseDto> CreateHotelAsync(HotelRequestDto hotelDto)
        {
            var hotel = new HotelEntity(hotelDto.HotelName,
                                hotelDto.Address,
                                hotelDto.City,
                                hotelDto.Description);

            await _hotelRepository.CreateHotelAsync(hotel);

            _logger.LogInformation("Hotel created successfully with ID: {HotelId}", hotel.Id);


            return new HotelResponseDto
            {
                Id = hotel.Id,
                HotelName = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                Description = hotel.Description,
                IsEnabled = hotel.IsEnabled
            };
        }

        public async Task DisabledAsync(Guid id)
        {
            var hotel = _hotelRepository.GetHotelByIdAsync(id).Result 
                         ?? throw new KeyNotFoundException($"Hotel with ID {id} not found.");
            hotel.Disable();

            await _hotelRepository.UpdateHotelAsync(hotel);

            _logger.LogInformation("Hotel disabled successfully with ID: {HotelId}", hotel.Id);
        }

        public async Task EnableAsync(Guid id)
        {
            var hotel = _hotelRepository.GetHotelByIdAsync(id).Result 
                         ?? throw new KeyNotFoundException($"Hotel with ID {id} not found.");

            hotel.Enable();

            await _hotelRepository.UpdateHotelAsync(hotel);


            _logger.LogInformation("Hotel enabled successfully with ID: {HotelId}", hotel.Id);

        }

   

        public async Task<IEnumerable<HotelResponseDto>> GetAllHotelsAsync( HotelFilterDto hotelFilterDto)
        {
            var hotels = await _hotelRepository.GetHotelsAllAsync(hotelFilterDto.Name,
                                                            hotelFilterDto.City,
                                                            hotelFilterDto.IsEnabled);


            _logger.LogInformation("Hotels get successfully");

            return hotels.Select(h => new HotelResponseDto
            {
                Id = h.Id,
                HotelName = h.Name,
                Address = h.Address,
                City = h.City,
                Description = h.Description,
                IsEnabled = h.IsEnabled
            });

            
        }

        public Task<IEnumerable<RoomResponseDto>> GetAvailableRoomsAsync(RoomAvailabilityFilterDto roomAvailabilityFilterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<HotelResponseDto?> GetHotelByIdAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id) 
                       ?? throw new KeyNotFoundException($"Hotel with ID {id} not found.");

            return new HotelResponseDto
            {

                Id = hotel.Id,
                HotelName = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                Description = hotel.Description,
                IsEnabled = hotel.IsEnabled

            };
        }

    
        public async Task<HotelResponseDto> UpdateAsync(Guid id, HotelRequestDto hotelDto)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id)
                        ?? throw new Exception($"Hotel with ID {id} not found.");

            _logger.LogInformation("Hotel find with ID: {HotelId}", hotel.Id);


            hotel.Update(hotelDto.HotelName,
                         hotelDto.Address,
                         hotelDto.City,
                         hotelDto.Description);

            await _hotelRepository.UpdateHotelAsync(hotel);

            return new HotelResponseDto
            {
                Id = hotel.Id,
                HotelName = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                Description = hotel.Description,
                IsEnabled = hotel.IsEnabled
            };
        }

     
    }
}
