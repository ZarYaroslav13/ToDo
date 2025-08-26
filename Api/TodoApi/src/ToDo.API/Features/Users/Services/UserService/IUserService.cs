using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Services.UserService;

public interface IUserService
{
    public Task<Result<string>> Login(string email, string password);
    
    public Task<IResult> Register(User user);
    
    public Task<Result<User>> GetInformation(int userId);
    
    public Task<Result<User>> Update(User user);
    public Task<IResult> UpdatePassword(int userId,string oldPassword, string newPassword);
    
    public Task<IResult> Delete(int userId);
}