using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using UltraGroup.Common.Responses;

namespace HotelService.API.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            // Validate
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error.");

                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Validation failed.",
                    Errors = ex.ValidationResult?.ErrorMessage?.Select(x => x.ToString())
                });
            }

            //No Found
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Resource not found.");
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Resource not found.",
                    Errors = [ex.Message]
                });
            }

            // Internal Server Error
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while processing the request");
                
                context.Response.StatusCode= (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new ApiResponse<object>
                {
                    Success = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "Internal Server Error",
                    Errors = [ex.Message]
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
