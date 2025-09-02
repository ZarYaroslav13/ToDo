using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Users.Commands.LoginUserCommand;

public class LoginEndpoint : BaseEndpoint<LoginUserCommand>
{
    public override string EndpointUrl => "/authorization/login";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Post;

    protected override Action<RouteHandlerBuilder> ConfigureEndpoint { get; } = config => config.AllowAnonymous();
}