using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Features.Users.Services.TokenService;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Services.UserService;

public class UserService : BaseService, IUserService
{
    private readonly DbSet<User> _users;
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;

    public UserService(AppDbContext context, ITokenService tokenService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _users = context.Users;
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));; 
    }
    
    public async Task<Result<string>> Login(string email, string password)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
                return Result<string>.Fail(message: "email or password wrong");

            var identity = _tokenService.GetUserIdentity(user);
            
            var token = _tokenService.CreateToken(identity); 
            
            return Result<string>.Success(data:token, message:"Logged successfully");
        });
    }

    public async Task<IResult> Register(User user)
    {
        return await ExecuteAsync(async () =>
        {
            if(user == null)
                return Result<User>.Fail("User is null");
        
            if(_users.Any(u => u.Email == user.Email))
                return Result<User>.Fail("Email is already registered");
        
            await _users.AddAsync(user);
        
            await _context.SaveChangesAsync();
        
            return Result.Success("User created successfully");
        });
    }

    public async Task<Result<User>> GetInformation(int userId)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if(user == null)
                throw new ArgumentException("User not found");
            
            return Result<User>.Success(new User()
            {
                Id = userId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
            });
        });
    }

    public async Task<Result<User>> Update(User user)
    {
        return await ExecuteAsync(async () =>
        {
            _users.Update(user);

            await _context.SaveChangesAsync();
            
            return Result<User>.Success(user,"User updated successfully");
        });
    }

    public async Task<IResult> Delete(int userId)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _users.FindAsync(userId);

            _users.Remove(user);

            await _context.SaveChangesAsync();
            
            return Result.Success("User deleted successfully");
        });
    }
}