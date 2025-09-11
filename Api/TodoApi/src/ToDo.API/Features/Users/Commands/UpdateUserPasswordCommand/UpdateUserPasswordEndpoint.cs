using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Users.Commands.UpdateUserPasswordCommand;

public class UpdateUserPasswordEndpoint : BaseEndpoint<UpdateUserPasswordCommand>
{
    public override string EndpointUrl { get; } = "/users/update-user-password";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Patch;
}