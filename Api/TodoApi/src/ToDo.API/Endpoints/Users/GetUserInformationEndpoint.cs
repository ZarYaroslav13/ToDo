using MediatR;
using ToDo.API.Endpoints.Base;
using ToDo.API.Features.Users.Queries.GetUserInformation;

namespace ToDo.API.Endpoints.Users;

public class GetUserInformationEndpoint : BaseEndpoint<GetUserInformationQuery>
{
    public override string EndpointUrl { get; } = "/users/{id:int}";
    public override EndpointHttpMethod EndpointHttpMethod { get; }  = EndpointHttpMethod.Get;

    public override void Register(IEndpointRouteBuilder builder)
    {
        builder.MapGet(EndpointUrl, HandleAsync).RequireAuthorization();
    }

    public async Task<IResult> HandleAsync(int id, IMediator mediator, CancellationToken cancellationToken)
    {
        return await base.Handle(new GetUserInformationQuery(){ UserId = id}, mediator, cancellationToken);
    }
}