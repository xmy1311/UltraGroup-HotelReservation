using Reservation.App.Interfaces;
using Reservation.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Reservation.App.DTOs;
using Reservation.Domain.Entities;

namespace Reservation.App.Services
{
    public class ReservationService(IReservationRepository reservationRepository,
        INotificationService notificationService,
        IHotelClient hotelClient,
        ILogger<ReservationService> logger) : IReservationService
    {
  
        private readonly IReservationRepository _reservationRepository = reservationRepository;
        private readonly INotificationService _notificationService = notificationService;
        private readonly IHotelClient _hotelClient = hotelClient;
        private readonly ILogger<ReservationService> _logger = logger;

       
        public async Task<ReservationResponseDto> CreateReservationAsync(ReservationRequestDto reservationRequestDto)
        {
            ArgumentNullException.ThrowIfNull(reservationRequestDto);

            var validateRoom = await _reservationRepository.IsRoomAvailableAsync(
                                reservationRequestDto.RoomId,
                                reservationRequestDto.CheckIn,
                                reservationRequestDto.CheckOut);
            if(!validateRoom)
                throw new InvalidOperationException("La hibatación no se encuentra disponible para esas fechas.");

            var reservation = new ReservationEntity(reservationRequestDto.RoomId,
                                                    reservationRequestDto.HotelId,
                                                    reservationRequestDto.CheckIn,
                                                    reservationRequestDto.CheckOut,
                                                    reservationRequestDto.NumberOfGuests,
                                                    reservationRequestDto.EmergencyContactName,
                                                    reservationRequestDto.EmergencyContactPhone);

            foreach (var guestDto in reservationRequestDto.Guests)
            {
                reservation.AddGuest(new GuestEntity(
                    guestDto.FirstName,
                    guestDto.LastName,
                    guestDto.BirthDate,
                    guestDto.Gender,
                    guestDto.DocumentType,
                    guestDto.DocumentNumber,
                    guestDto.Email,
                    guestDto.PhoneNumber

                    ));
            }

            

            reservation.Confirm();

            reservation = await _reservationRepository.CreateReservationAsync(reservation);

            var guest = reservation.Guests.First();

            await _notificationService.SendReservationConfirmationAsync(
                reservation.Id,
                guest.Email,
                $"{guest.FirstName} {guest.LastName}",
                "agent@ultragroup.com"
                );

            _logger.LogInformation("Reserva creada id:{reservationId}", reservation.Id);

            return MapToResponse(reservation);
        }

        public async Task<IEnumerable<ReservationResponseDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllReservationsAsync();

            _logger.LogInformation("Consulta realizada con exito");

            return reservations.Select(MapToResponse);
        }

        public async Task<ReservationResponseDto?> GetReservationByIdAsync(Guid reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId)
                             ?? throw new NotImplementedException();

         
            _logger.LogInformation($"Reserva id: {reservationId}");

            return MapToResponse(reservation);
        }

        async Task IReservationService.CancelReservationAsync(Guid id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id)
                              ?? throw new NotImplementedException();

            reservation.Cancel();

            await _reservationRepository.UpdateReservationAsync(reservation);

            _logger.LogInformation("id:{reservation}", reservation.Id);
        }

     
        async Task<IEnumerable<AvailableRoomDto>> IReservationService.GetAvailableRoomAsync(
                                            string city, 
                                            DateTime checkIn, 
                                            DateTime checkOut, 
                                            int numberOfGuests)
        {
            var rooms= await _hotelClient.GetAvailableRoomsAsync(city, numberOfGuests);

            var availableRooms = new List<AvailableRoomDto>();

            foreach (var room in rooms) {
                var isAvailable =
                    await _reservationRepository.IsRoomAvailableAsync(room.RoomId, checkIn, checkOut);

                if (isAvailable)
                    availableRooms.Add(room);
            }

            return availableRooms;
        }
        
     

        private static ReservationResponseDto MapToResponse(ReservationEntity reservation)
        {
            return new ReservationResponseDto
            {
                ReservationId = reservation.Id,
                HotelId = reservation.HotelId,
                RoomId = reservation.RoomId,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                NumberOfGuests = reservation.NumberOfGuests,
                Status = reservation.Status,
                EmergencyContactName = reservation.EmergencyContactName,
                EmergencyContactPhone = reservation.EmergencyContactPhone,
                CreatedAt = reservation.CreatedAt,

                Guests = reservation.Guests.Select(g => new GuestDto
                {
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    BirthDate = g.BirthDate,
                    Gender = g.Gender,
                    DocumentType = g.DocumentType,
                    DocumentNumber = g.DocumentNumber,
                    Email = g.Email,
                    PhoneNumber = g.PhoneNumber
                }).ToList()
            };
        }
    }
}
