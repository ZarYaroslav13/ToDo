using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace ToDo.API.Endpoints.Base;

public abstract class BaseEndpoint<TRequest> : IEndpoint
{
    public abstract string EndpointUrl { get; }
    public abstract EndpointHttpMethod EndpointHttpMethod { get; }

    protected virtual Delegate ConfigureHandler() => HandleAsync;

    protected virtual Action<RouteHandlerBuilder>? ConfigureEndpoint { get; } = null;

    public virtual void Register(IEndpointRouteBuilder builder)
    {
        var  endpointRouteBuilder = RegisterEndpoint(builder);
        
        ConfigureEndpoint?.Invoke(endpointRouteBuilder);
    }

    public virtual async Task<IResult> HandleAsync(
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

    private RouteHandlerBuilder RegisterEndpoint(IEndpointRouteBuilder builder)
    {
        var handleAsync = ConfigureHandler();
        
        switch (EndpointHttpMethod)
        {
            case EndpointHttpMethod.Get:
                return builder.MapGet(EndpointUrl, ConfigureHandler());
            case EndpointHttpMethod.Post:
                return builder.MapPost(EndpointUrl, handleAsync);
            case EndpointHttpMethod.Put:
                return builder.MapPut(EndpointUrl, handleAsync);
            case EndpointHttpMethod.Patch:
                return builder.MapPatch(EndpointUrl, handleAsync);
            case EndpointHttpMethod.Delete:
                return builder.MapDelete(EndpointUrl, handleAsync);
            default:
                throw new ArgumentException($"Invalid endpoint http method, cannot register endpoint with url {EndpointUrl} and http method {EndpointHttpMethod}");
        }
    }
}