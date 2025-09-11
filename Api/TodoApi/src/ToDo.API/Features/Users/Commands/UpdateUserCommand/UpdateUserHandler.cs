using MediatR;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Commands.UpdateUserCommand;

public class UpdateUserHandler : BaseRequestHandler, IRequestHandler<UpdateUserCommand, IResult<User>>
{
    private readonly AppDbContext _context;
    
    public UpdateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var existedUser = await _context.Users.FindAsync(request.Id);
            
            existedUser.Name = request.Name;
            existedUser.Email = request.Email;
            existedUser.Surname = request.Surname;

            await _context.SaveChangesAsync();
            
            return Result<User>.Success(request.ToUser(),"User updated successfully");
        });
    }
}