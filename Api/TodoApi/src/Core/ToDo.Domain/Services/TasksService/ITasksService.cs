using ToDo.Domain.Entities;

namespace ToDo.Domain.Services.TasksService;

public interface ITasksService : IService
{
    public Task<UserTask> CreateAsync(UserTask task);
    
    public Task<UserTask> UpdateAsync(UserTask task);
    
    public Task<UserTask> DeleteAsync(int id);
}