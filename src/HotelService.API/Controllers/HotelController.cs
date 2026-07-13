using HotelService.App.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UltraGroup.Common.Responses;
using System.Net;
using HotelService.App.Services;
using HotelService.App.Interfaces;

namespace HotelService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController(IHotelServices hotelServices) : ControllerBase
    {
        private readonly IHotelServices _hotelServices = hotelServices;
       

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelRequestDto createHotelDto)
        {
            var hotelResponse = await _hotelServices.CreateHotelAsync(createHotelDto);

            return Created( string.Empty,new ApiResponse<HotelResponseDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Hotel creado",
                Data = hotelResponse
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels([FromQuery] HotelFilterDto hotelFilterDto)
        {
            var hotelsFiterResponse = await _hotelServices.GetAllHotelsAsync(hotelFilterDto);

            return Ok(new ApiResponse<IEnumerable<HotelResponseDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada con exito",
                Data = hotelsFiterResponse
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var hotelResponse = await _hotelServices.GetHotelByIdAsync(id);

            return Ok(new ApiResponse<HotelResponseDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada con exito",
                Data = hotelResponse
            });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelRequestDto updateHotelDto)
        {

         var HotelResponse=  await _hotelServices.UpdateAsync(id,updateHotelDto);

            return Created(string.Empty,new ApiResponse<object>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Hotel actualizado",
                Data = HotelResponse
            });
        }

        [HttpPost("disable/{id}")]
        public async Task<IActionResult> DisableHotel(Guid id)
        {
            await _hotelServices.DisabledAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Hotel deshabilitado",
                Data = null
            });
        }
        [HttpPost("enabled/{id}")]
        public async Task<IActionResult> EnableHotel(Guid id)
        {
            await _hotelServices.EnableAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Hotel habilitado",
                Data = null
            });
        }

    }
}
