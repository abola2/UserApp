using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace LoginBackend.controller;


[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("login")]
public class RegisterController(UserService userService) : ControllerBase
{
    
    private readonly IUserService _userService = userService;


    [HttpPost]
    public IActionResult Register([FromBody] UserRequest user)
    {
        if (_userService.AlreadyExist(user.Name))
        {
            return BadRequest("User already exists.");
        }

        if (String.IsNullOrEmpty(user.Password) && String.IsNullOrEmpty(user.Name))
        {
            return BadRequest("Password and Name are required.");
        }

        _userService.AddUser(user);
        return Created("/users/" + user.Name, user);
    }
    
    
}