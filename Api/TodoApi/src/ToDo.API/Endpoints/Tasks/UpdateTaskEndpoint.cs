using MediatR;
using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Tasks.Commands.UpdateTaskCommand;

namespace ToDo.API.Endpoints.Tasks;

public class UpdateTaskEndpoint : BaseEndpoint<UpdateTaskCommand>
{
    public override string EndpointUrl { get; } = "/tasks/{id}";
    public override EndpointHttpMethod EndpointHttpMethod { get; }  = EndpointHttpMethod.Put;
    
}