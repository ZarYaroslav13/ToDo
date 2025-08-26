using System.Security.Claims;
using ToDo.API.Infrastructure.Entities;

namespace ToDo.API.Features.Users.Services.TokenService;

public interface ITokenService
{
    public string CreateToken(ClaimsIdentity identity);

    public ClaimsIdentity GetUserIdentity(User user);
}
