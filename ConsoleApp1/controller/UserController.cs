using ConsoleApp1.model;
using ConsoleApp1.service;

namespace ConsoleApp1.controller;

public class UserController
{
    private readonly IUserService _userService;
    private readonly IBookService _bookService;
    
    
    public UserController()
    {
        _userService = new UserSerivce();
        _bookService = new BookSerivce();
    }

    public User AddUser()
    {
        return _userService.AddUser();
    }

    public User? GetUser(User user)
    {
        
        return _userService.Login(user);
    }
    

    public void addBook(User user, Book book)
    {
        _bookService.AddBook(user, book);
    }
    
}