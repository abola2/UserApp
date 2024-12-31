// See https://aka.ms/new-console-template for more information

using ConsoleApp1.controller;
using ConsoleApp1.model;
using ConsoleApp1.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IUserService, UserSerivce>();
services.AddSingleton<IBookService, BookSerivce>();
services.AddSingleton<UserDatabase>();
services.AddSingleton<ConsoleManager>();
services.AddSingleton<UserController>();
var serviceProvider = services.BuildServiceProvider();



    Start();


    void Start()
    {
        
        
        ConsoleManager cm = serviceProvider.GetRequiredService<ConsoleManager>();
        cm.ReadUserInput();
    }



