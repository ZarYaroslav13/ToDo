using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace ToDo.API.Endpoints.Base;

public abstract class BaseEndpoint<TRequest> : IEndpoint
{
    public abstract string EndpointUrl { get; }
    
    public abstract void Register(IEndpointRouteBuilder builder);

    public virtual async Task<IResult> Handle(
        [FromBody]TRequest request, 
        IMediator mediator, 
        CancellationToken cancellationToken)
    {
        if (mediator == null)
            throw new ArgumentNullException(nameof(mediator));

        var responseType = typeof(TRequest)
            .GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>))
            ?.GetGenericArguments()
            .FirstOrDefault();

        if (responseType == null)
            return Results.BadRequest("Invalid request type.");

        dynamic baseResponse = await mediator.Send(request, cancellationToken);

        return baseResponse.Succeeded 
            ? Results.Ok(baseResponse) 
            : Results.BadRequest(baseResponse);
    }
}