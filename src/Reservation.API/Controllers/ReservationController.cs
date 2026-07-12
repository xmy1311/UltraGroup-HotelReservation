using Microsoft.AspNetCore.Mvc;
using Reservation.App.DTOs;
using Reservation.App.Interfaces;
using System.Net;
using UltraGroup.Common.Responses;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController(IReservationService reservationService) 
                : ControllerBase
    {
       private readonly IReservationService _reservationService= reservationService;


        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationRequestDto reservationRequestDto)
        {
            var reservation= await _reservationService.CreateReservationAsync(reservationRequestDto);

            return Created(string.Empty,
                new ApiResponse<ReservationResponseDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Hotel created",
                Data= reservation
            });

        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRervationId(Guid id)
        {
            var reservation= await _reservationService.GetReservationByIdAsync(id);
            return Ok(new ApiResponse<ReservationResponseDto>
            {
                Success= true,
                StatusCode= HttpStatusCode.OK,
                Message="get reservation succes",
                Data=reservation
            });
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();

            return Ok(new ApiResponse<IEnumerable<ReservationResponseDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "get reservation succes",
                Data = reservations
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> CancelReservation(Guid id)
        {
            await _reservationService.CancelReservationAsync(id);

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "get reservation succes",
                Data = true
            });
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms(
                      [FromQuery] AvailableRoomFilterDto filterDto)
        {
           var rooms= await _reservationService.GetAvailableRoomAsync(
               filterDto.City,
               filterDto.CheckIn,
               filterDto.CheckOut,
               filterDto.NumberOfGuests);

            return Ok(new ApiResponse<IEnumerable<AvailableRoomDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "get reservation succes",
                Data = rooms
            });
        }

    }
}

