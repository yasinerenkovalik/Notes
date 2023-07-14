using Microsoft.AspNetCore.Mvc;
using Notes.Application.Services;
using Notes.Domail;
using Notes.Persistence.Repository;
using Notes.Persistence.Services;

namespace Notes.API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserContoller : ControllerBase
{
    private readonly IUserService _userService;

    public UserContoller(IUserService userService)
    {
        _userService = userService;
    }
    // GET
    [HttpPost("add")]
    public IActionResult Add(User user)
    {
       var result= _userService.Add(user);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result= _userService.GetAll();
        return Ok(result);
    }

  
}