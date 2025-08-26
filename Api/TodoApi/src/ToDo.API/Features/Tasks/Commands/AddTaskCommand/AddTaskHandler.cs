using MediatR;
using ToDo.API.Features.Tasks.Services.UserTasksService;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Commands.AddTaskCommand;

public class AddTaskHandler :  IRequestHandler<AddTaskCommand, Result<UserTask>>
{
    private readonly IUserTaskService  _userTaskService;

    public AddTaskHandler(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService ?? throw new ArgumentNullException(nameof(userTaskService));;
    }

    public async Task<Result<UserTask>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        return await _userTaskService.AddTaskAsync(request.ToTask());
    }
}