using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ToDo.API.Features.Users.Commands.DeleteUserCommand;

public class DeleteUserCommand : IRequest<Wrappers.Result.IResult>
{
    [Required]
    public int UserId { get; set; }
}