using System.Text.Json;
using MediatR;

namespace ToDo.API.Features.Commons.Behaviour;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var options = new JsonSerializerOptions() { WriteIndented = true };

        _logger.LogInformation("FinanceManagerApi Request Handling: {Name} \n{Request}", typeof(TRequest).Name, JsonSerializer.Serialize(request, options));
        var response = await next();
        _logger.LogInformation("FinanceManagerApi Response Handling: {Name} \n{Response}", typeof(TResponse).Name, JsonSerializer.Serialize(response, options));

        return response;
    }
}
