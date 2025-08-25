using MediatR;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Commands.LoginUserCommand;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<string>>
{
    private readonly IUserService _userService;
    
    public LoginUserHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));;
    }
    
    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.Login(request.Email, request.Password);
    }
}