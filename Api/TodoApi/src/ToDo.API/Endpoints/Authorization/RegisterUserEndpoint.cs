using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.RegisterUserCommand;

namespace ToDo.API.Endpoints.Authorization;

public class RegisterUserEndpoint : BaseEndpoint<RegisterUserCommand>
{
    public override string EndpointUrl => "/authorization/register";
}