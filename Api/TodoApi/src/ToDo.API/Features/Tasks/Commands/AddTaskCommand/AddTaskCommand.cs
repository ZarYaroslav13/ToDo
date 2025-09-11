using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Infrastructure.Enums;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Commands.AddTaskCommand;

public class AddTaskCommand : IRequest<Result<UserTask>>
{
    [Required]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    public TaskPriority Priority { get; set; }
    
    [Required]
    public DateTime Deadline { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }

    public UserTask ToTask()
    {
        return new()
        {
            Title = this.Title,
            Description = this.Description,
            Priority = this.Priority,
            Deadline = this.Deadline,
            UserId = this.UserId,
        };
    }
}