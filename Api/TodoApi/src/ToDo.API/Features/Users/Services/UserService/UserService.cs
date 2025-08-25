using Microsoft.EntityFrameworkCore;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

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
        var user = await _users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        
        return 
            user == null 
                ? Result<string>.Fail(message:"email or password wrong") 
                : Result<string>.Success(data:"token", message:"Logged successfully");
    }

    public async Task<Result<User>> Register(User user)
    {
        if(user == null)
            return Result<User>.Fail("User is null");
        
        if(_users.Any(u => u.Email == user.Email))
            return Result<User>.Fail("Email is already registered");
        
        await _users.AddAsync(user);
        
        await _context.SaveChangesAsync();
        
        return Result<User>.Success(user);
    }

    public async Task<Result<User>> Update(User user)
    {
        try
        {
            _users.Update(user);

            await _context.SaveChangesAsync();
            
            return Result<User>.Success(user,"User updated successfully");
        }
        catch (Exception e)
        {
            return Result<User>.Fail(e.Message);
        }
    }

    public async Task<IResult> Delete(int userId)
    {
        try
        {
            var user = await _users.FindAsync(userId);

            _users.Remove(user);

            await _context.SaveChangesAsync();
            
            return Result.Success("User deleted successfully");
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
    
    
}