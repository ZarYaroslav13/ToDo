using MediatR;
using ToDo.API.Features.Users.Commands.LoginUserCommand;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Wrappers.Result;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;


namespace ToDo.API.Endpoints.Users;

public class LoginEndpoint : IEndpoint
{
    public const string Url = "/users/login";

    public void Register(IEndpointRouteBuilder builder)
    {
        builder.MapPost(Url, Handle);
    }

    public async Task<IResult> Handle(LoginUserCommand request, IMediator mediator, CancellationToken cancellationToken)
    {
        if(mediator == null)
            throw new ArgumentNullException(nameof(mediator));
        
        var baseResponse = await mediator.Send(request, cancellationToken);

        return baseResponse.Succeeded ? Results.Ok(baseResponse) : Results.BadRequest(baseResponse);

    } 
}