using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.LoginUserCommand;


namespace ToDo.API.Endpoints.Authorization;

public class LoginBaseEndpoint : BaseEndpoint<LoginUserCommand>
{
    public override string EndpointUrl => "/authorization/login";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Post;

    protected override Action<RouteHandlerBuilder> ConfigureEndpoint { get; } = config => config.AllowAnonymous();
}