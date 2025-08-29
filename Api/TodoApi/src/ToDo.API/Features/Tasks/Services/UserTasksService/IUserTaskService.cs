using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Tasks.Services.UserTasksService;

public interface IUserTaskService
{
    public Task<Result<List<UserTask>>> GetUserTasksAsync(int userId);

    public Task<Result<UserTask>> GetUserTaskAsync(int id);
    
    public Task<Result<UserTask>> AddTaskAsync(UserTask newTask);
    
    public Task<Result<UserTask>> UpdateTaskAsync(UserTask updatedTask);
    
    public Task<IResult> DeleteTaskAsync(int taskId);
}