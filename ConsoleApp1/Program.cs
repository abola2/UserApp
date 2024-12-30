// See https://aka.ms/new-console-template for more information

using ConsoleApp1.controller;
using ConsoleApp1.service;


    

    Start();


    void Start()
    {
        UserController userController = new UserController();
        ConsoleManager cm = new ConsoleManager(userController);
        cm.ReadUserInput();
    }



