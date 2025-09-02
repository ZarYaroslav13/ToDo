using MediatR;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.DeleteUserCommand;

public class DeleteUserHandler : BaseRequestHandler, IRequestHandler<DeleteUserCommand, IResult>
{
    private readonly AppDbContext _context;
    
    public DeleteUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _context.Users.FindAsync(request.UserId);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            
            return Result.Success("User deleted successfully");
        });
    }
}