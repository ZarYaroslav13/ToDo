using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ToDo.API.Features.Users.Services.TokenService;

public class AuthOptions
{
    public const string Auth = "Auth";

    public string ISSUER { get; set; }
    public string AUDIENCE { get; set; }
    public string KEY { get; set; }
    public int LIFETIME_IN_MINETS { get; set; }

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF32.GetBytes(KEY));
    }

}