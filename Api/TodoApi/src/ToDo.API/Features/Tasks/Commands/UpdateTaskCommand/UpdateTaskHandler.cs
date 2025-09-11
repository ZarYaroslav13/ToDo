using MediatR;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskHandler : BaseRequestHandler, IRequestHandler<UpdateTaskCommand, Result<UserTask>>
{
    private readonly AppDbContext _context;

    public UpdateTaskHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UserTask>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var existedTask = await _context.Tasks.FindAsync(request.Id);
            
            existedTask.Title = request.Title;
            existedTask.Description = request.Description;
            existedTask.Deadline = request.Deadline;
            existedTask.Priority = request.Priority;

            await _context.SaveChangesAsync();
            
            return Result<UserTask>.Success(existedTask,"User task updated successfully");
        });
    }
}