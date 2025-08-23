// See https://aka.ms/new-console-template for more information

using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
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

var app = builder.Build();

app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);
app.MapControllers();





UserDatabase database = serviceProvider.GetRequiredService<UserDatabase>();
database.Database.EnsureCreated();


app.Run();






