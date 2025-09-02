using MediatR;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Commands.AddTaskCommand;

public class AddTaskHandler : BaseRequestHandler,  IRequestHandler<AddTaskCommand, Result<UserTask>>
{
    private readonly AppDbContext _context;

    public AddTaskHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UserTask>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var newTask = request.ToTask();
            
            if(newTask == null)
                throw new ArgumentNullException(nameof(newTask));
            
            var createdTask = await _context.Tasks.AddAsync(newTask);

            await _context.SaveChangesAsync();

            return Result<UserTask>.Success(createdTask.Entity, "The task added successfully");
        });
    }
}