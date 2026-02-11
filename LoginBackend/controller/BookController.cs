using LoginBackend.mapper;
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
            return Unauthorized("Old session");
        }

        var newBook = _bookService.AddBook(loginUser, book);
        var dto = new BookDto
        {
            Id = newBook.Uuid,
            Title = newBook.Name,
            Author = newBook.Author,
        };
        return Ok(dto);
    }
    
    [HttpGet("get")]
    public IActionResult GetBooks()
    {
        Request.Cookies.TryGetValue("token", out var token);

        User? loginUser = _userService.GetUser(token);

        if (loginUser == null)
        {
            return Unauthorized("Old session");
        }

        var books = _bookService.GetBooks(loginUser);
        var modifiedBooks = BookMapper.BooksToDto(books);
        return Ok(modifiedBooks);
    }
    
    
    [HttpPost("remove")]
    public IActionResult RemoveBook([FromBody] RemoveBook removeBook)
    {
        Request.Cookies.TryGetValue("token", out var token);

        User? loginUser = _userService.GetUser(token);

        if (loginUser == null)
        {
            return Unauthorized("Old session");
        }

        if (removeBook.Id == null)
        {
            return BadRequest("id is null");
        }
        
        var book = _bookService.GetBook(loginUser, removeBook.Id);

        _bookService.DeleteBook(loginUser, book);
        
        return Ok();
    }


    
    
    
}