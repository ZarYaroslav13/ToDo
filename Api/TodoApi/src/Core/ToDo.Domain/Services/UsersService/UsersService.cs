using ToDo.Domain.Entities;

namespace ToDo.Domain.Services.UsersService;

public class UsersService : IUsersService
{
    public UsersService()
    {
        
    }
    
    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(string username)
    {
        throw new NotImplementedException();
    }
}