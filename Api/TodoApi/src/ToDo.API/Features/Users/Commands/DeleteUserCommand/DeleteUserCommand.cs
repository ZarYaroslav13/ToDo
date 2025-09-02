using System.ComponentModel.DataAnnotations;
using MediatR;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.DeleteUserCommand;

public class DeleteUserCommand : IRequest<IResult>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }
}