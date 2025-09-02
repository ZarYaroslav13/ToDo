using MediatR;
using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Users.Commands.DeleteUserCommand;

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