using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskEndpoint : BaseEndpoint<UpdateTaskCommand>
{
    public override string EndpointUrl { get; } = "/tasks/{id}";
    public override EndpointHttpMethod EndpointHttpMethod { get; }  = EndpointHttpMethod.Put;
    
}