using System.Text;
using Microsoft.IdentityModel.Tokens;

public static class JwtOptions
{
    public const string ISSUER = "YourIssuer";
    public const string AUDIENCE = "YourAudience";
    private const string KEY = "mysupersecretkey_must_be_at_least_32_bytes_long!"; 



    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}