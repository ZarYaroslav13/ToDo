using System.ComponentModel.DataAnnotations;
using MediatR;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.UpdateUserPasswordCommand;

public class UpdateUserPasswordCommand : IRequest<IResult>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long."), MaxLength(32, ErrorMessage = "The password must be at least 32 characters long.")]
    public string OldPassword { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long."), MaxLength(32, ErrorMessage = "The password must be at least 32 characters long.")]
    public string NewPassword { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long."), MaxLength(32, ErrorMessage = "The password must be at least 32 characters long.")]
    public string ConfirmPassword { get; set; }
}