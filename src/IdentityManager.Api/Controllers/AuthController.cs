using IdentityManager.Application.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Api.Controllers;

[ApiController]
[Route("apli/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserUseCase _userUseCase;

    public AuthController(IJwtService jwtService, IUserUseCase userUseCase)
    {
        _jwtService = jwtService;
        _userUseCase = userUseCase;
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = _userUseCase.AuthenticateUser(request.Username, request.Password);
            var token = _jwtService.GenerateToken(request.Username, user.Role);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost("register")]
    public ActionResult Register([FromBody] RegisterRequest request)
    { 
        try
        {
            _userUseCase.RegisterUser(request.Username, request.Password, request.Role);
            return Ok("User registered successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class RegisterRequest
{ 
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
