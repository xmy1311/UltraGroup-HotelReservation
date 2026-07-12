using HotelService.App.DTOs;
using HotelService.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UltraGroup.Common.Responses;

namespace HotelService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomServices roomServices) : ControllerBase
    {
      private readonly IRoomServices _roomServices= roomServices;

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomRequestDto createRoomDto)
        {
            var roomResponse = await _roomServices.CreateRoomAsync(createRoomDto);

            return Ok(new ApiResponse<RoomResponseDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Room created successfully",
                Data = roomResponse
            });
        
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var roomResponse = await _roomServices.GetByIdAsync(id);
          
            return Ok(new ApiResponse<RoomResponseDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Room retrieved successfully",
                Data = roomResponse
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomsByHotelId(Guid hotelId)
        {
            var roomsResponse = await _roomServices.GetByHotelAsync(hotelId);

            return Ok(new ApiResponse<IEnumerable<RoomResponseDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Rooms retrieved successfully",
                Data = roomsResponse
            });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRoom(Guid id, [FromBody] RoomRequestDto updateRoomDto)
        {

            var roomResponse = await _roomServices.UpdateAsync(id, updateRoomDto);
    

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Room updated successfully",
                Data = roomResponse
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableRoom([FromQuery] string city,
            [FromQuery] int capacity)
        {

            var rooms= await _roomServices.GetRoomByCityAsync(city, capacity);


            return Ok(new ApiResponse<IEnumerable<RoomResponseDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Room updated successfully",
                Data = rooms
            });
        }
    }
}
