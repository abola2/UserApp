// See https://aka.ms/new-console-template for more information

using ConsoleApp1.controller;
using ConsoleApp1.model;
using ConsoleApp1.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IUserService, UserSerivce>();
services.AddSingleton<IBookService, BookSerivce>();
services.AddSingleton<UserDatabase>();
services.AddSingleton<UserSerivce>();
var serviceProvider = services.BuildServiceProvider();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});


UserDatabase database = serviceProvider.GetRequiredService<UserDatabase>();
database.Database.EnsureCreated();





app.MapPost("/login", async (User user) =>
{

    UserSerivce us = serviceProvider.GetRequiredService<UserSerivce>();

    if (!us.AlreadyExist(user.Name))
    {
        return Results.BadRequest("Wrong username or password");
    }

    User? loginUser = us.Login(user);

    if (loginUser == null)
    {
        return Results.BadRequest("Wrong username or password");
    }
    
    return Results.Created("/users/" + user.Name, user);
});

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






