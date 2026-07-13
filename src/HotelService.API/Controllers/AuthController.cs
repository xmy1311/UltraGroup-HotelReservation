using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UltraGroup.Common.Responses;
using UltraGroup.Common.Security;
using UltraGroup.Common.Security.DTOs;

namespace HotelService.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IJwtService jwtService, IConfiguration configuration) : ControllerBase
    {

        private readonly IConfiguration _configuration = configuration;

        private readonly IJwtService _jwtService = jwtService;

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            var userName = _configuration["Auth:UserName"];
            var password = _configuration["Auth:Password"];

            if (request.UserName != userName ||
                request.Password != password)

                
            {
                return Unauthorized(new ApiResponse<string>
                {
                    Success = false,
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "Usuario o contraseña incorrectos."
                });
            }

            var token = _jwtService.GenerateToken(request.UserName);

            return Ok(new ApiResponse<LoginResponseDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Inicio de sesión exitoso.",
                Data = token
            });
        }
    }
}
    
