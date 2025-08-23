using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.controller;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    
    private readonly IUserService _userService;
    private readonly IBookService _bookService;
    
    public BookController(UserService userService, BookService bookService)
    {
        _userService = userService;
        _bookService = bookService;
    }
    
    [HttpPost("new")]
    public IActionResult AddBook([FromBody] Book? book)
    {
        Request.Cookies.TryGetValue("token", out var token);

        User? loginUser = _userService.GetUser(token);

        if (loginUser == null)
        {
            return BadRequest("Old session");
        }

        _bookService.AddBook(loginUser, book);
        
        return Ok();
    }
    
    [HttpGet("get")]
    public IActionResult GetBooks()
    {
        Request.Cookies.TryGetValue("token", out var token);

        User? loginUser = _userService.GetUser(token);

        if (loginUser == null)
        {
            return BadRequest("Old session");
        }

        return Ok(_bookService.GetBooks());
    }
    
    [HttpPost("remove")]
    public IActionResult RemoveBook([FromBody] Book? book)
    {
        Request.Cookies.TryGetValue("token", out var token);

        User? loginUser = _userService.GetUser(token);

        if (loginUser == null)
        {
            return BadRequest("Old session");
        }

        _bookService.AddBook(loginUser, book);
        
        return Ok();
    }


    
    
    
}