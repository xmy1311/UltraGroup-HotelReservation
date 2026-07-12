using System;
using System.Collections.Generic;
using System.Text;

namespace UltraGroup.Common.Security.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }
    }
}
