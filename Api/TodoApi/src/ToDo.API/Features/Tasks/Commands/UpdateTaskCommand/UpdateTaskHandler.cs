using MediatR;
using ToDo.API.Features.Tasks.Services.UserTasksService;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Result<UserTask>>
{
    private readonly IUserTaskService  _userTaskService;

    public UpdateTaskHandler(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService ?? throw new ArgumentNullException(nameof(userTaskService));;
    }

    public async Task<Result<UserTask>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        return await _userTaskService.UpdateTaskAsync(request.ToTask());
    }
}