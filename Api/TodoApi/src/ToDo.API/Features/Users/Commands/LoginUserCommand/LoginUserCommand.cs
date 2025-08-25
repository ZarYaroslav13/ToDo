using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Commands.LoginUserCommand;

public class LoginUserCommand : IRequest<Result<string>>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must have at least 8 characters"), MaxLength(32, ErrorMessage = "Password must have no more then 32 characters")]
    public string Password { get; set; }
}