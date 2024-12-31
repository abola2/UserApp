// See https://aka.ms/new-console-template for more information

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

UserDatabase database = serviceProvider.GetRequiredService<UserDatabase>();
database.Database.EnsureCreated();


app.MapPost("/register", async (User user) =>
{

    UserSerivce us = serviceProvider.GetRequiredService<UserSerivce>();

    if (us.AlreadyExist(user.Name))
    {
        return Results.BadRequest("User already exist");
    }

    us.AddUser(user);
    
    return Results.Created("/users/" + user.Name, user);
});


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

app.Run();




