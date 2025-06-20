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
    public async Task<ActionResult> SignUp(UserRequestDto userRequestDto)
    {
        await _authService.SignUp(userRequestDto);
        return Ok();
    }
}