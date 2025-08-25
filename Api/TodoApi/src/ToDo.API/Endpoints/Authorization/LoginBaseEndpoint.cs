using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.LoginUserCommand;


namespace ToDo.API.Endpoints.Authorization;

public class LoginBaseEndpoint : BaseEndpoint<LoginUserCommand>
{
    public override string EndpointUrl => "/authorization/login"; 
}