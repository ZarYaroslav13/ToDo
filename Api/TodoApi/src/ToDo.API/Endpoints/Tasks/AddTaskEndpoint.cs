using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Tasks.Commands.AddTaskCommand;

namespace ToDo.API.Endpoints.Tasks;

public class AddTaskEndpoint : BaseEndpoint<AddTaskCommand>
{
    public override string EndpointUrl { get; } = "/tasks";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Post;
}