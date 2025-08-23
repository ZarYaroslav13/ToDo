using ToDo.Domain.Entities.Base;

namespace ToDo.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public List<UserTask> Tasks { get; set; } = new();
}