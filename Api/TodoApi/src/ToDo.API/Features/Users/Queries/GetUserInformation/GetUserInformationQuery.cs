using System.ComponentModel.DataAnnotations;
using MediatR;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Queries.GetUserInformation;

public class GetUserInformationQuery : IRequest<Result<User>>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }
}