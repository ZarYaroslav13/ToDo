using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace ToDo.API.Endpoints.Base;

public abstract class BaseEndpoint<TRequest> : IEndpoint
{
    public abstract string EndpointUrl { get; }
    public abstract EndpointHttpMethod EndpointHttpMethod { get; }

    public virtual void Register(IEndpointRouteBuilder builder)
    {
        switch (EndpointHttpMethod)
        {
            case EndpointHttpMethod.Get:
                builder.MapGet(EndpointUrl, Handle);
                break;
            case EndpointHttpMethod.Post:
                builder.MapPost(EndpointUrl, Handle);
                break;
            case EndpointHttpMethod.Put:
                builder.MapPut(EndpointUrl, Handle);
                break;
            case EndpointHttpMethod.Patch:
                builder.MapPatch(EndpointUrl, Handle);
                break;
            case EndpointHttpMethod.Delete:
                builder.MapDelete(EndpointUrl, Handle);
                break;
                
        }
    }

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