using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.controller;


[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    
    private readonly UserService _userService;
    
    public LoginController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public IActionResult Login([FromBody] UserRequest user)
    {
        if (!_userService.AlreadyExist(user.Name))
        {
            return BadRequest("Wrong username or password");
        }

        User? loginUser = _userService.Login(user);

        if (loginUser == null)
        {
            return BadRequest("Wrong username or password");
        }
    
        return Ok(loginUser.SessionToken.Token);
    }
    
    
}