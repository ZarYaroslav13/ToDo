using System.ComponentModel.DataAnnotations;
using MediatR;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Tasks.Commands.DeleteTaskCommand;

public class DeleteTaskCommand:IRequest<IResult>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}