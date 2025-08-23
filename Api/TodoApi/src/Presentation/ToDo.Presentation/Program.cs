using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDo.Infrastructure;
using ToDo.Presentation.Endpoints;
using ToDo.Presentation.Extensions.HostBuilder;
using ToDo.Presentation.Extensions.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Configure();
builder.AddServices();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceManagerApi", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header,
            }, new List<string>()
        }
    });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseApplicationMiddleware();

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

var endpointsGroup = app.MapGroup("/");
EndpointsProvider.RegisterAppEndpoints(endpointsGroup);
app.MapGet("/hello", () =>
    {
        return "Hello World!";
    })
    .WithName("HelloEndpoint")
    .WithOpenApi();

app.Run();
