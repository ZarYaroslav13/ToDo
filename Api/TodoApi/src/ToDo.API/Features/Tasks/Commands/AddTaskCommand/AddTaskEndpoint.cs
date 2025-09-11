using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Tasks.Commands.AddTaskCommand;

public class AddTaskEndpoint : BaseEndpoint<AddTaskCommand>
{
    public override string EndpointUrl { get; } = "/tasks";
    public override EndpointHttpMethod EndpointHttpMethod { get; } = EndpointHttpMethod.Post;
}