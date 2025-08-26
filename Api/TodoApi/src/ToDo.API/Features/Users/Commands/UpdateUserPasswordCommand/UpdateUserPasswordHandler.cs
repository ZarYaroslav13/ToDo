using MediatR;
using ToDo.API.Features.Users.Services.UserService;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.UpdateUserPasswordCommand;

public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, IResult>
{
    private readonly IUserService _userService;

    public UpdateUserPasswordHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));;
    }
    
    public async Task<IResult> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _userService.UpdatePassword(request.UserId, request.OldPassword, request.NewPassword);
    }
}