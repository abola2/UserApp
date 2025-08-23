using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.controller;


[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    
    private readonly IUserService _userService;
    
    public RegisterController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public IActionResult Register([FromBody] UserRequest user)
    {
        if (_userService.AlreadyExist(user.Name))
        {
            return BadRequest("User already exists.");
        }

        _userService.AddUser(user);
        return Created("/users/" + user.Name, user);
    }
    
    
}