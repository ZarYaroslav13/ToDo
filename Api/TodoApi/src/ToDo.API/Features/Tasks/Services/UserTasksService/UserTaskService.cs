using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Tasks.Services.UserTasksService;

public class UserTaskService : BaseService, IUserTaskService
{
    private readonly DbSet<UserTask> _userTasks;
    private readonly AppDbContext _context;

    public UserTaskService(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userTasks = context.Tasks;
    }
    
    public async Task<Result<List<UserTask>>> GetUserTasksAsync(int userId)
    {
        return await ExecuteAsync(async () =>
        {
            var userTasks = await _userTasks
                .Where(t => t.UserId == userId)
                .AsNoTracking()
                .ToListAsync();

            return Result<List<UserTask>>.Success(userTasks, "Tasks retrieved successfully");
        });
    }

    public async Task<Result<UserTask>> AddTaskAsync(UserTask newTask)
    {
        return await ExecuteAsync(async () =>
        {
            if(newTask == null)
                throw new ArgumentNullException(nameof(newTask));
            
            var createdTask = await _userTasks.AddAsync(newTask);

            await _context.SaveChangesAsync();

            return Result<UserTask>.Success(createdTask.Entity, "The task added successfully");
        });
    }

    public async Task<Result<UserTask>> UpdateTaskAsync(UserTask updatedTask)
    {
        return await ExecuteAsync(async () =>
        {
            var existedUser = await _userTasks.FindAsync(updatedTask.Id);
            
            var entry = _context.Entry(existedUser);
            
            updatedTask.UserId = existedUser.UserId;
            
            entry.CurrentValues.SetValues(updatedTask);

            await _context.SaveChangesAsync();
            
            return Result<UserTask>.Success(updatedTask,"User task updated successfully");
        });
    }

    public async Task<IResult> DeleteTaskAsync(int taskId)
    {
        return await ExecuteAsync(async () =>
        {
            var task = await _userTasks.FindAsync(taskId);

            _userTasks.Remove(task);

            await _context.SaveChangesAsync();
            
            return Result.Success("UserTask deleted successfully");
        });
    }
}