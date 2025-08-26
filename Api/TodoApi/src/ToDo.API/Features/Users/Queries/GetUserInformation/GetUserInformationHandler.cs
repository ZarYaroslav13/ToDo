using MediatR;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Queries.GetUserInformation;

public class GetUserInformationHandler : IRequestHandler<GetUserInformationQuery, Result<User>>
{
    private readonly IUserService _userService;
    
    public GetUserInformationHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));;
    }
    
    public async Task<Result<User>> Handle(GetUserInformationQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetInformation(request.UserId);
    }
}