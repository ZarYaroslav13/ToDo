using MediatR;
using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Tasks.Commands.DeleteTaskCommand;

public class DeleteTaskEndpoint :  BaseEndpoint<DeleteTaskCommand>
{
    public override string EndpointUrl { get; } = "/tasks/{id:int}";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Delete;
    
    protected override Delegate ConfigureHandler()
    {
        return async (int id,  IMediator mediator, CancellationToken cancellationToken) =>
        {
            return await base.HandleAsync(new (){ Id = id}, mediator, cancellationToken);
        };
    }
}