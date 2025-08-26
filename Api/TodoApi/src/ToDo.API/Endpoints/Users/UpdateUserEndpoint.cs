using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.UpdateUserCommand;

namespace ToDo.API.Endpoints.Users;

public class UpdateUserEndpoint : BaseEndpoint<UpdateUserCommand>
{
    public override string EndpointUrl { get; } = "/users";
    public override EndpointHttpMethod EndpointHttpMethod { get; } =  EndpointHttpMethod.Put;
}