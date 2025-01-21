// See https://aka.ms/new-console-template for more information

using ConsoleApp1.model;
using ConsoleApp1.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IUserService, UserService>();
services.AddSingleton<IBookService, BookService>();
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
    
    IUserService us = serviceProvider.GetRequiredService<IUserService>();

    User? user = us.GetSession(authorizationHeader.FirstOrDefault());

    if (user == null)
    {
        return Results.BadRequest("Invalid token");
    }
    
    return Results.Ok(user.Name);
});

app.MapPost("/book", (HttpContext httpContext) =>
{
    if (!httpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
    {
        return Results.Unauthorized();
    }
    
    IUserService us = serviceProvider.GetRequiredService<IUserService>();
    IBookService bs = serviceProvider.GetRequiredService<IBookService>();

    User? user = us.GetSession(authorizationHeader.FirstOrDefault());

    if (user == null)
    {
        return Results.BadRequest("Invalid token");
    }

    Book book = bs.CreateBook("author", "tittle", "pla pla plaa");
    
    
    
    return Results.Ok(book.Name);
});


app.Run();






