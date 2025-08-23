using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.controller;


[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    
    private readonly IUserService _userService;
    
    public LoginController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("hello")]
    public IActionResult Hello()
    {
        string authToken = Request.Headers.Authorization;
        
        var loggedUser = _userService.GetUser(authToken);

        if (loggedUser != null)
        {
            return Ok();
        }
        return Unauthorized();
    }


    [HttpPost("user")]
    public IActionResult Login([FromBody] UserRequest? user)
    {

        string authToken = Request.Headers.Authorization;
        
        var loggedUser = _userService.GetUser(authToken);

        if (loggedUser != null)
        {
            return Ok(loggedUser.SessionToken.Token);
        }
        
        
        User? loginUser = _userService.Login(user, authToken);

        if (loginUser == null)
        {
            return BadRequest("Wrong username or password");
        }
    
        return Ok(loginUser.SessionToken.Token);
    }
    
    
}