using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Query.GetUserTasksCommand;

public class GetUserTasksHandler : BaseRequestHandler, IRequestHandler<GetUserTasksCommand, Result<List<UserTask>>>
{
    private readonly AppDbContext _context;

    public GetUserTasksHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Result<List<UserTask>>> Handle(GetUserTasksCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var userTasks = await _context.Tasks
                .Where(t => t.UserId == request.UserId)
                .AsNoTracking()
                .ToListAsync();

            return Result<List<UserTask>>.Success(userTasks, "Tasks retrieved successfully");
        });
    }
}