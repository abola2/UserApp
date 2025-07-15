using LoginBackend.model;
using LoginBackend.service;
using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.controller;


[ApiController]
[Route("image")]
public class ImageController : ControllerBase
{
    
    private readonly IUserService _userService;
    
    public ImageController(UserService userService)
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
        
        String token = Request.Headers.Authorization;

        User? loginUser = _userService.Login(user, token);

        if (loginUser == null)
        {
            return BadRequest("Wrong username or password");
        }
    
        return Ok(loginUser.SessionToken.Token);
    }
    
    
}