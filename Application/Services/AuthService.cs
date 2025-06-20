using Microsoft.AspNetCore.Identity;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public async Task SignUp(UserRequestDto userRequestDto)
    {
        var user = new IdentityUser
        {
            UserName = userRequestDto.Email,
            Email = userRequestDto.Email
        };

        var result = await _userManager.CreateAsync(user, userRequestDto.PasswordHash);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }
    }
}