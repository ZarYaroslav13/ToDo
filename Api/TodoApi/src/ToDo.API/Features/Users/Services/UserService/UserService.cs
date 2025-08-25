using Microsoft.EntityFrameworkCore;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace ToDo.API.Features.Users.Services.UserService;

public class UserService : IUserService
{
    private readonly DbSet<User> _users;
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _users = context.Users;
    }
    
    
    public async Task<Result<string>> Login(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<User>> Register(User user)
    {
        if(user == null)
            return Result<User>.Fail("User is null");
        
        var registeredUser = await _users.AddAsync(user);
        
        return await Result<User>.SuccessAsync(user);
    }

    public async Task<Result<User>> Update(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> Delete()
    {
        throw new NotImplementedException();
    }
}