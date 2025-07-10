using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityManager.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace IdentityManager.Infrastructure.Services;

public class JwtService : IJwtService
{
    private readonly string _key;
    private readonly string _issuer;
    public JwtService(string key, string issuer)
    {
        _key = key;
        _issuer = issuer;
    }

    /// <summary>
    /// Generates a JWT token for the given username and role.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="role"></param>
    /// <returns>Returns the generated Tolken</returns>
    public string GenerateToken(string username, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _issuer,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Validates the given JWT token and returns the ClaimsPrincipal if valid.
    /// </summary>
    /// <param name="token"></param>
    /// <returns>returns ClaimsPrincipal</returns>
    public ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_key);
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = _issuer,
            ValidateAudience = true,
            ValidAudience = _issuer,
            ValidateLifetime = true
        };
        try
        {
            return tokenHandler.ValidateToken(token, validationParameters, out _);
        }
        catch
        {
            return null;
        }
    }
}
