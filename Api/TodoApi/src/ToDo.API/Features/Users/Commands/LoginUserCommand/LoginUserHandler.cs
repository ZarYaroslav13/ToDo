using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Features.Users.Services.TokenService;
using ToDo.API.Infrastructure;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Commands.LoginUserCommand;

public class LoginUserHandler : BaseRequestHandler, IRequestHandler<LoginUserCommand, Result<string>>
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    
    public LoginUserHandler(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }
    
    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _context.Users
                                .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password, cancellationToken);

            if (user == null)
                return Result<string>.Fail(message: "email or password wrong");

            var identity = _tokenService.GetUserIdentity(user);
            
            var token = _tokenService.CreateToken(identity); 
            
            return Result<string>.Success(data:token, message:"Logged successfully");
        });
    }
}