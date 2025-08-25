using Microsoft.EntityFrameworkCore;
using ToDo.API.Infrastructure;

namespace ToDo.API.Extensions.HostBuilder;

public static class AddServicesConfigurationHostBuilderExtensions
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        services
            .AddDbConnection(configuration)
            .AddDomainServices();
        
        
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

    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        /*var servicesTypes = typeof(IService);

        var domainServices = servicesTypes.Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .Where(t => t != null);

        foreach (var domainService in domainServices)
        {
            if (servicesTypes.IsAssignableFrom(domainService.Service))
                services.AddTransient(domainService.Service, domainService.Implementation);
        }*/

        return services;
    }
}