using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Infrastructure;
using ToDo.API.Infrastructure.Entities;
using ToDo.API.Wrappers.Result;

namespace ToDo.API.Features.Users.Queries.GetUserInformation;

public class GetUserInformationHandler : BaseRequestHandler, IRequestHandler<GetUserInformationQuery, Result<User>>
{
    private readonly AppDbContext _context;
    
    public GetUserInformationHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Result<User>> Handle(GetUserInformationQuery request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId);

            if(user == null)
                throw new ArgumentException("User not found");
            
            return Result<User>.Success(new User()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
            });
        });
    }
}