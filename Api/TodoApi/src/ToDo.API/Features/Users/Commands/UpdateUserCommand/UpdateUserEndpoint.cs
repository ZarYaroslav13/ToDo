using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Users.Commands.UpdateUserCommand;

public class UpdateUserEndpoint : BaseEndpoint<UpdateUserCommand>
{
    public override string EndpointUrl { get; } = "/users";
    public override EndpointHttpMethod EndpointHttpMethod { get; } =  EndpointHttpMethod.Put;
}