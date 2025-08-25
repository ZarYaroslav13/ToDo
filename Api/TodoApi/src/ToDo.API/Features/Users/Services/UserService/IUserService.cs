using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace ToDo.API.Features.Users.Services.UserService;

public interface IUserService
{
    public Task<Result<string>> Login(string email, string password);
    
    public Task<Result<User>> Register(User user);
    
    public Task<Result<User>> Update(User user);
    
    public Task<IResult> Delete();
}