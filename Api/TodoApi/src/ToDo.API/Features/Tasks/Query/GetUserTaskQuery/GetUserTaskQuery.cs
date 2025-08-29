using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Tasks.Query.GetUserTaskQuery;

public class GetUserTaskQuery : IRequest<Result<UserTask>>
{
    [Required]
    public int Id { get; set; }
}