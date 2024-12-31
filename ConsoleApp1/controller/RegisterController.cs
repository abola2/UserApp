using ConsoleApp1.model;
using ConsoleApp1.service;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.controller;


[ApiController]
public class RegisterController : ControllerBase
{
    
    private readonly UserSerivce _userSerivce;
    
    public RegisterController(UserSerivce userSerivce)
    {
        _userSerivce = userSerivce;
    }


    [HttpPost("register")]
    public IActionResult register(User user)
    {

        if (_userSerivce.AlreadyExist(user.Name))
        {
            return BadRequest("User already exist");
        }

        _userSerivce.AddUser(user);
    
        return Created("/users/" + user.Name, user);
    }
    
    

    
    
    
}