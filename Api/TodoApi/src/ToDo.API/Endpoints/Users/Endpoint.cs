namespace ToDo.API.Endpoints.Users;

public abstract class Endpoint<TRequset> : IEndpoint

{
    public abstract string EndpointUrl { get; }
    public abstract void Register(IEndpointRouteBuilder builder);
}