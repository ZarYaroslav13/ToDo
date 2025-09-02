using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.RegisterUserCommand;

public class RegisterUserHandler : BaseRequestHandler, IRequestHandler<RegisterUserCommand, IResult>
{
    private readonly AppDbContext _context;
    
    public RegisterUserHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var user = request.ToUser();
        
            if(await _context.Users.AnyAsync(u => u.Email == user.Email))
                return Result<User>.Fail("Email is already registered");
        
            await _context.Users.AddAsync(user);
        
            await _context.SaveChangesAsync();
        
            return Result.Success("User created successfully");
        });
    }
}