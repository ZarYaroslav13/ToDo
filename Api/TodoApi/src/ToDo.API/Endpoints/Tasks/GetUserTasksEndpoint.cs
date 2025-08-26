using MediatR;
using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Tasks.Query.GetUserTasksCommand;

namespace ToDo.API.Endpoints.Tasks;

public class GetUserTasksEndpoint : BaseEndpoint<GetUserTasksCommand>
{
    public override string EndpointUrl { get; } =  "/tasks/users/{id:int}";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Get;

    protected override Delegate ConfigureHandler()
    {
        return async (int id,  IMediator mediator, CancellationToken cancellationToken) =>
        {
            return await base.HandleAsync(new (){ UserId = id}, mediator, cancellationToken);
        };
    }
}