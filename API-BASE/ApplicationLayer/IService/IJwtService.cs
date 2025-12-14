using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IService
{
    public interface IJwtService
    {
        string GenerateToken(Dictionary<string, string> claims, int expiryMinutes);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
