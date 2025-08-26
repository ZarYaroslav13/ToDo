using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Query.GetUserTasksCommand;

public class GetUserTasksCommand : IRequest<Result<List<UserTask>>>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }
}