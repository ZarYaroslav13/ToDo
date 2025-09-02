using MediatR;
using ToDo.API.Features.Commons;

namespace ToDo.API.Features.Users.Queries.GetUserInformation;

public class GetUserInformationEndpoint : BaseEndpoint<GetUserInformationQuery>
{
    public override string EndpointUrl { get; } = "/users/{id:int}";
    public override EndpointHttpMethod EndpointHttpMethod { get; }  = EndpointHttpMethod.Get;

    protected override Delegate ConfigureHandler()
    {
        return async (int id,  IMediator mediator, CancellationToken cancellationToken) =>
        {
            return await base.HandleAsync(new (){ UserId = id}, mediator, cancellationToken);
        };
    }
}