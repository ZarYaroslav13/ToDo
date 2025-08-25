using MediatR;
using ToDo.API.Features.Users.Services.UserService;

namespace ToDo.API.Features.Users.Commands.RegisterUserCommand;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Wrappers.Result.IResult>
{
    private readonly IUserService _userService;

    public RegisterUserHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));;
    }
    
    public async Task<Wrappers.Result.IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.Register(request.ToUser());
    }
}