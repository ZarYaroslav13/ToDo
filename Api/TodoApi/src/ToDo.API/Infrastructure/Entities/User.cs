using ToDo.API.Infrastructure.Entities.Base;

namespace ToDo.API.Infrastructure.Entities;

public class User : Entity
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public List<UserTask> Tasks { get; set; } = new();
}