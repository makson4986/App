using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto userRequestDto)
    {
        var registerResult = await _authService.Register(userRequestDto);

        if (!registerResult)
        {
            return Conflict("User already exists!");
        }

        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var token = await _authService.Login(loginDto);

        if (token == null)
        {
            return Unauthorized("Invalid credentials!");
        }

        return Ok(token);
    }

    [HttpGet("profile")]
    public IActionResult Profile()
    {
        return Ok(_authService.Profile());
    }
}