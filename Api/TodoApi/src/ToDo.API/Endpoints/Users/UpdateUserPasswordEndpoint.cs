using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.UpdateUserPasswordCommand;

namespace ToDo.API.Endpoints.Users;

public class UpdateUserPasswordEndpoint : BaseEndpoint<UpdateUserPasswordCommand>
{
    public override string EndpointUrl { get; } = "/users/update-user-password";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Patch;
}