// See https://aka.ms/new-console-template for more information

using System.Threading.RateLimiting;
using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<UserDatabase>();
services.AddSingleton<UserService>();
services.AddSingleton<BookService>();
var serviceProvider = services.BuildServiceProvider();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>(); 
builder.Services.AddScoped<BookService>(); 
builder.Services.AddScoped<UserDatabase>(); 

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 100,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1)
            }));

    options.AddFixedWindowLimiter("login", limiterOptions =>
    {
        limiterOptions.PermitLimit = 10;
        limiterOptions.Window = TimeSpan.FromMinutes(1);
    });
});

var app = builder.Build();

//Todo unsafe
app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);
app.UseRateLimiter();
app.MapControllers();

UserDatabase database = serviceProvider.GetRequiredService<UserDatabase>();
database.Database.EnsureCreated();


app.Run();






