using MediatR;
using ToDo.API.Features.Tasks.Services.UserTasksService;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Tasks.Commands.DeleteTaskCommand;

public class DeleteTaskHandler :  IRequestHandler<DeleteTaskCommand, IResult>
{
    private readonly IUserTaskService  _userTaskService;

    public DeleteTaskHandler(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService ?? throw new ArgumentNullException(nameof(userTaskService));;
    }

    public async Task<IResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        return await _userTaskService.DeleteTaskAsync(request.Id);
    }
}