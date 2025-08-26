using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Infrastructure.Enums;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskCommand : IRequest<Result<UserTask>>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    public TaskPriority Priority { get; set; }
    
    [Required]
    public DateTime Deadline { get; set; }

    public UserTask ToTask()
    {
        return new()
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            Priority = this.Priority,
            Deadline = this.Deadline
        };
    }
}