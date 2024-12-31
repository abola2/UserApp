using ConsoleApp1.model;
using ConsoleApp1.service;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.controller;


[ApiController]
[Route("register")]
public class RegisterController : ControllerBase
{
    
    private readonly UserService _userService;
    
    public RegisterController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public IActionResult Register([FromBody] User user)
    {
        if (_userService.AlreadyExist(user.Name))
        {
            return BadRequest("User already exists.");
        }

        _userService.AddUser(user);
        return Created("/users/" + user.Name, user);
    }
    
    
}