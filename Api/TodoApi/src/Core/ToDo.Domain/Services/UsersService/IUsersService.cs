using ToDo.Domain.Entities;

namespace ToDo.Domain.Services.UsersService;

public interface IUsersService  : IService
{
    public Task<List<User>> GetAllAsync();
    
    public Task<User> GetUserAsync(string username);
    
    public Task<User> AddUserAsync(User user);
    
    public Task<User> UpdateUserAsync(User user);
    
    public Task<bool> DeleteUserAsync(string username);
}