using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDo.API.Features.Commons.Behaviour;
using ToDo.API.Features.Users.Services.TokenService;
using ToDo.API.Infrastructure;

namespace ToDo.API.Extensions.HostBuilder;

public static class AddServicesConfigurationHostBuilderExtensions
{
    public static IHostApplicationBuilder AddApiServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        builder
            .AddJwtAuthentication()
            .AddCORS();

        services
            .AddDatabase(configuration)
            .AddServices()
            .AddMediator();
        
        return builder;
    }
    
    private static IHostApplicationBuilder AddJwtAuthentication(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        builder.Services.Configure<AuthOptions>(
            builder.Configuration.GetSection(AuthOptions.Section));
        
        AuthOptions authOptions = configuration
            .GetSection(AuthOptions.Section)
            .Get<AuthOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = authOptions.ISSUER,
                    ValidAudience = authOptions.AUDIENCE,

                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                };
            });

        services.AddAuthorization();
        
        return builder;
    }
    
    private static IHostApplicationBuilder AddCORS(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;
        const string allowedOriginsSection = "AllowedOrigins";

        var allowedOrigins = configuration
            .GetSection(allowedOriginsSection)
            .Get<string[]>();
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowCors",
                policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
        
        return builder;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(option =>
            option.
                UseSqlServer(
                    configuration.
                        GetConnectionString("DbConnection")));

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<TokenService>();
        
        return services;
    }
    
    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

        return services;
    }
}