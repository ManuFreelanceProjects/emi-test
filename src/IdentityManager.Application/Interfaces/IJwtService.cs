using System.Security.Claims;

namespace IdentityManager.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(string userName, string role);
    ClaimsPrincipal ValidateToken(string token);
}
