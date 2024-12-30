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

    public void addUser(User user)
    {
        _userService.AddUser(user);
    }

    public void addBook(User user, Book book)
    {
        _bookService.AddBook(user, book);
    }
    
}