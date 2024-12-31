using ConsoleApp1.model;
using ConsoleApp1.service;

namespace ConsoleApp1.controller;

public class UserController
{
    private readonly IUserService _userService;
    private readonly IBookService _bookService;
    
    
    public UserController(IUserService userService, IBookService bookService)
    {
        _userService = userService;
        _bookService = bookService;
    }

    public User AddUser()
    {
        return _userService.AddUser();
    }

    public User? GetUser(User user)
    {
        
        return _userService.Login(user);
    }
    
    
}