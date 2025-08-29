using MediatR;
using ToDo.API.Features.Tasks.Services.UserTasksService;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Query.GetUserTaskQuery;

public class GetUserTaskHandler : IRequestHandler<GetUserTaskQuery, Result<UserTask>>
{
    private readonly IUserTaskService  _userTaskService;

    public GetUserTaskHandler(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService ?? throw new ArgumentNullException(nameof(userTaskService));;
    }

    public async Task<Result<UserTask>> Handle(GetUserTaskQuery request, CancellationToken cancellationToken)
    {
        return await _userTaskService.GetUserTaskAsync(request.Id);
    }
}