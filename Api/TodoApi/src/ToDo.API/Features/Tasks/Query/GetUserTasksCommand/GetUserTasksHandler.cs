using MediatR;
using ToDo.API.Features.Tasks.Services.UserTasksService;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Query.GetUserTasksCommand;

public class GetUserTasksHandler : IRequestHandler<GetUserTasksCommand, Result<List<UserTask>>>
{
    private readonly IUserTaskService  _userTaskService;

    public GetUserTasksHandler(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService ?? throw new ArgumentNullException(nameof(userTaskService));;
    }
    
    public async Task<Result<List<UserTask>>> Handle(GetUserTasksCommand request, CancellationToken cancellationToken)
    {
        return await _userTaskService.GetUserTasksAsync(request.UserId);
    }
}