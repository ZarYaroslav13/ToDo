using ToDo.API.Infrastructure.Entities.Base;
using ToDo.API.Infrastructure.Enums;

namespace ToDo.API.Infrastructure.Entities;

public class UserTask : Entity
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public TaskPriority Priority { get; set; }
    
    public DateTime Deadline { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}