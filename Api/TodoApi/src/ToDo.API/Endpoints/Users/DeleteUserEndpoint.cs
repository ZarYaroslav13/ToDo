using MediatR;
using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Commands.DeleteUserCommand;

namespace ToDo.API.Endpoints.Users;

public class DeleteUserEndpoint : BaseEndpoint<DeleteUserCommand>
{
    public override string EndpointUrl { get; } = "/users/{id:int}";
    public override EndpointHttpMethod EndpointHttpMethod { get; } =  EndpointHttpMethod.Delete;

    protected override Delegate ConfigureHandler()
    {
        return async (int id,  IMediator mediator, CancellationToken cancellationToken) =>
        {
            return await base.HandleAsync(new (){ UserId = id}, mediator, cancellationToken);
        };
    }
}