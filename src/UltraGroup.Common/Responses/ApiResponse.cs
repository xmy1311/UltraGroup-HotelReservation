using System.Net;

namespace UltraGroup.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public IEnumerable<string>? Errors { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
 
    }
}
