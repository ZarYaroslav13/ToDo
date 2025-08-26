using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.RegisterUserCommand;

namespace ToDo.API.Endpoints.Authorization;

public class RegisterUserEndpoint : BaseEndpoint<RegisterUserCommand>
{
    public override string EndpointUrl => "/authorization/register";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Post;

    protected override Action<RouteHandlerBuilder> ConfigureEndpoint { get; } = config => config.AllowAnonymous();
}