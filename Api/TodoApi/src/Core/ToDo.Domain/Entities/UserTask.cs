using ToDo.Domain.Entities.Base;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities;

public class UserTask : Entity
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public TaskPriority Priority { get; set; }
    
    public DateTime Deadline { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}