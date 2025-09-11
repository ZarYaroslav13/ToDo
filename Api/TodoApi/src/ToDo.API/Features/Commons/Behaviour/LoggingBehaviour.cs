using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;

namespace ToDo.API.Features.Commons.Behaviour;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var options = new JsonSerializerOptions() { WriteIndented = true };

        _logger.LogInformation("FinanceManagerApi Url:{Url} Request Handling: {Name} \n{Request} ", _httpContextAccessor.HttpContext?.Request.GetDisplayUrl(), typeof(TRequest).Name, JsonSerializer.Serialize(request, options));
        var response = await next();
        _logger.LogInformation("FinanceManagerApi Response Handling: {Name} \n{Response}", typeof(TResponse).Name, JsonSerializer.Serialize(response, options));

        return response;
    }
}
