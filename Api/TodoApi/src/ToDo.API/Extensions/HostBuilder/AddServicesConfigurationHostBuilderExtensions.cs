using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Features.Commons;
using ToDo.API.Features.Commons.Behaviour;
using ToDo.API.Features.Users.Services.TokenService;
using ToDo.API.Features.Users.Services.UserService;
using ToDo.API.Infrastructure;

namespace ToDo.API.Extensions.HostBuilder;

public static class AddServicesConfigurationHostBuilderExtensions
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        builder.AddOptions();

        services
            .AddDbConnection(configuration)
            .AddFeaturesServices();

        services.AddMediator();
        
        return builder;
    }
    
    private static IHostApplicationBuilder AddOptions(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<AuthOptions>(
            builder.Configuration.GetSection(AuthOptions.Auth));

        return builder;
    }

    
    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        const string connectionString = "DbConnection";

        services.AddDbContext<AppDbContext>(option =>
            option.
                UseSqlServer(
                    configuration.
                        GetConnectionString(connectionString)));

        return services;
    }

    private static IServiceCollection AddFeaturesServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        
        /*var servicesTypes = typeof(BaseService);

        var featuresServices = servicesTypes.Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .Where(t => t != null);

        foreach (var featureService in featuresServices)
        {
            if (servicesTypes.IsAssignableFrom(featureService.Service))
                services.AddTransient(featureService.Service, featureService.Implementation);
        }
*/
        return services;
    }
    
    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

        return services;
    }
}