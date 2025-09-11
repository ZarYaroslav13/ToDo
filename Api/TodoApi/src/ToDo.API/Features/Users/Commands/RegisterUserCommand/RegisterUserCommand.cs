using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using IResult = ToDo.API.Wrappers.Result.IResult;

namespace ToDo.API.Features.Users.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<IResult>
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long."), MaxLength(32, ErrorMessage = "The password must be at least 32 characters long.")]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long."), MaxLength(32, ErrorMessage = "The password must be at least 32 characters long.")]
    public string ConfirmPassword { get; set; }

    public User ToUser() => new()
    {
        Name = Name,
        Surname = Surname,
        Email = Email,
        Password = Password,
    };
}