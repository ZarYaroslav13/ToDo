using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDo.API.Features.Commons;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Infrastructure.Entities;

namespace ToDo.API.Features.Users.Services.TokenService;

public class TokenService : BaseService, ITokenService
{
    private readonly AuthOptions _authOptions;

    public TokenService(IOptions<AuthOptions> authOptions)
    {
        ArgumentNullException.ThrowIfNull(authOptions);
        _authOptions = authOptions.Value ?? throw new ArgumentNullException(nameof(authOptions.Value));
    }

    public string CreateToken(ClaimsIdentity identity)
    {
        var now = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
                issuer: _authOptions.ISSUER,
                audience: _authOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authOptions.LIFETIME_IN_MINETS)),
                signingCredentials: new(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    
    public ClaimsIdentity GetUserIdentity(User user)
    {
        var claims = new List<Claim>()
        {
            new(nameof(user.Id), user.Id.ToString()),
            new(ClaimsIdentity.DefaultNameClaimType, user.Email),
        };

        ClaimsIdentity identity = new(claims, "Token",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return identity;
    }
}
