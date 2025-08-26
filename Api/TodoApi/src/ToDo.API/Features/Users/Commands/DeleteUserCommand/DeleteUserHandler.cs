using MediatR;
using ToDo.API.Features.Users.Services.UserService;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.DeleteUserCommand;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, IResult>
{
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));;
    }

    public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.Delete(request.UserId);
    }
}