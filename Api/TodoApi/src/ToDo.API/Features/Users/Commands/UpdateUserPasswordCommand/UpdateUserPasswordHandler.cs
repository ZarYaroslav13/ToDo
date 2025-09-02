using MediatR;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.UpdateUserPasswordCommand;

public class UpdateUserPasswordHandler : BaseRequestHandler, IRequestHandler<UpdateUserPasswordCommand, IResult>
{
    private readonly AppDbContext _context;
    
    public UpdateUserPasswordHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IResult> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var existedUser = await _context.Users.FindAsync(request.UserId);
            
            if(existedUser.Password != request.OldPassword)
                throw new ArgumentException("Passwords do not match");
            
            existedUser.Password = request.NewPassword;

            await _context.SaveChangesAsync();
            
            return Result.Success("User password updated successfully");
        });
    }
}