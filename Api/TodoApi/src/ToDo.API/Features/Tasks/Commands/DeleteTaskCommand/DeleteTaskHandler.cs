using MediatR;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Tasks.Commands.DeleteTaskCommand;

public class DeleteTaskHandler : BaseRequestHandler,  IRequestHandler<DeleteTaskCommand, IResult>
{
    private readonly AppDbContext _context;

    public DeleteTaskHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var task = await _context.Tasks.FindAsync(request.Id);

            _context.Tasks.Remove(task);

            await _context.SaveChangesAsync();
            
            return Result.Success("UserTask deleted successfully");
        });
    }
}