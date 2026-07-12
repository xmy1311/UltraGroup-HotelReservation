using System;
using System.Collections.Generic;
using System.Text;
using UltraGroup.Common.Security.DTOs;

namespace UltraGroup.Common.Security
{
    public interface IJwtService
    {
        LoginResponseDto GenerateToken(string userName);
    }
}
