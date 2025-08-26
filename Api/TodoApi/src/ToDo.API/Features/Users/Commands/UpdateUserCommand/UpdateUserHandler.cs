using MediatR;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Infrastructure.Entities;

namespace ToDo.API.Features.Users.Commands.UpdateUserCommand;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Wrappers.Result.IResult<User>>
{
    private readonly IUserService _userService;

    public UpdateUserHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));;
    }

    public async Task<Wrappers.Result.IResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.Update(request.ToUser());
    }
}