using MediatR;
using ToDo.API.Features.Users.Commands.LoginUserCommand;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Wrappers.Result;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Endpoints.Base;
using IResult = Microsoft.AspNetCore.Http.IResult;


namespace ToDo.API.Endpoints.Users;

public class LoginBaseEndpoint : BaseEndpoint<LoginUserCommand>
{
    public override string EndpointUrl => "/users/login"; 

    public override void Register(IEndpointRouteBuilder builder)
    {
        builder.MapPost(EndpointUrl, Handle);
    }
}