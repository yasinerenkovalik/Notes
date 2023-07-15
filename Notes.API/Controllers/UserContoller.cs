using Microsoft.AspNetCore.Mvc;
using Notes.Application.Services;
using Notes.Domail;


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
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result= _userService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]

    public IActionResult Delete(User user)
    {
        var result = _userService.Delete(user);
        return Ok(result);
    }
    [HttpPost("update")]

    public IActionResult Update(User user)
    {
        var result = _userService.Update(user);
        return Ok(result);
    }

    [HttpPost("login")]
    public IActionResult Login(string mail, string password)
    {
        var result = _userService.Login(mail, password);
        if (result!=null)
        {
            return Ok("giriş başarılı");
        }

        return Ok("giriş başarıısız");
    }
   
    

  
}