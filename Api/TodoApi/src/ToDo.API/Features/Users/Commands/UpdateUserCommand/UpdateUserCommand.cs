using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Commands.UpdateUserCommand;

public class UpdateUserCommand : IRequest<IResult<User>>
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public User ToUser() => new()
    {
        Id = Id,
        Name = Name,
        Surname = Surname,
        Email = Email
    };
}