using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public class AuthService : BaseService<User, RegisterDto, RegisterResponseDto>
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IPasswordHasher<User> passwordHasher, AuthRepository authRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(authRepository, mapper)
    {
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<bool> Register(RegisterDto userRequestDto)
    {
        User user = _mapper.Map<User>(userRequestDto);
        user.PasswordHash = _passwordHasher.HashPassword(user, userRequestDto.PasswordHash);


        try
        {
            await _repository.AddAsync(user);
        }
        catch (DbUpdateException)
        {
            return false;
        }

        return true;

    }

    public async Task<string?> Login(LoginDto loginDto)
    {
        User? user = await GetByEmail(loginDto.Email);

        if (user == null)
        {
            return null;
        }

        var loginResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

        if (loginResult == PasswordVerificationResult.Failed)
        {
            return null;
        }

        return GenerateJwtToken(user);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await ((AuthRepository)_repository).GetByEmail(email);
    }

    public UserProfileDto Profile()
    {
        var httpContext = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is not available.");

        var user = httpContext.User.Identity ?? throw new UnauthorizedAccessException("User identity is not available.");

        var roleString = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(roleString))
        {
            throw new UnauthorizedAccessException("User isn't authorized");
        }

        if (!Enum.TryParse<Role>(roleString, ignoreCase: true, out var role))
        {
            throw new UnauthorizedAccessException("Invalid user role");
        }

        return new UserProfileDto(user.Name, role);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = JwtOptions.GetSymmetricSecurityKey();
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: JwtOptions.ISSUER,
            audience: JwtOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}