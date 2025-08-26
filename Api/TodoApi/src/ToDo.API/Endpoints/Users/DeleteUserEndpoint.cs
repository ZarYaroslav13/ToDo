using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.DeleteUserCommand;

namespace ToDo.API.Endpoints.Users;

public class DeleteUserEndpoint : BaseEndpoint<DeleteUserCommand>
{
    public override string EndpointUrl { get; } = "/users";
    public override EndpointHttpMethod EndpointHttpMethod { get; } =  EndpointHttpMethod.Delete;
}