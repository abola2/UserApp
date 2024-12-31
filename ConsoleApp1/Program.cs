// See https://aka.ms/new-console-template for more information

using ConsoleApp1.model;
using ConsoleApp1.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IUserService, UserService>();
services.AddSingleton<IBookService, BookSerivce>();
services.AddSingleton<UserDatabase>();
services.AddSingleton<UserService>();
var serviceProvider = services.BuildServiceProvider();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>(); 
builder.Services.AddScoped<UserDatabase>(); 
var app = builder.Build();

app.MapControllers();
app.UseRouting();


UserDatabase database = serviceProvider.GetRequiredService<UserDatabase>();
database.Database.EnsureCreated();



app.MapGet("/hello", (HttpContext httpContext) =>
{
    if (!httpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
    {
        return Results.Unauthorized();
    }
    
    UserDatabase ud = serviceProvider.GetRequiredService<UserDatabase>();

    User? user = ud.Users.FirstOrDefault(u => u.Uuid == authorizationHeader.FirstOrDefault());

    if (user == null)
    {
        return Results.BadRequest("Wrong username or password");
    }
    
    return Results.Ok(user);
});

app.Run();






