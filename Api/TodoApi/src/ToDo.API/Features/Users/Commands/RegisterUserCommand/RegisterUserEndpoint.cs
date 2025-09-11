using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Users.Commands.RegisterUserCommand;

public class RegisterUserEndpoint : BaseEndpoint<RegisterUserCommand>
{
    public override string EndpointUrl => "/authorization/register";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Post;

    protected override Action<RouteHandlerBuilder> ConfigureEndpoint { get; } = config => config.AllowAnonymous();
}