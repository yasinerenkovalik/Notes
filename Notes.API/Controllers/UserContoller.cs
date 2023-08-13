using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Notes.Application.Services;
using Notes.Domail;
using MailKit.Security;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Net.Mail;



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
        return Ok("kayıt işlemi tamamlandı");
    }

    [HttpGet("get")]
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
    public IActionResult Login(string email, string password)
    {
        var result = _userService.Login(email, password);
        
        if (result!=null)
        {
            return Ok(result);
        }

        return Ok("false");
    }

    [HttpPost("mail")]
    public IActionResult SendMail()
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("avcikiz25@gmail.com"));
        email.To.Add(MailboxAddress.Parse("erenkovalik42@gmail.com"));
        email.Subject = "test mail";
        email.Body = new TextPart(TextFormat.Html) { Text = "merhabalarr" };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com",587,SecureSocketOptions.StartTls);
        smtp.Authenticate("erenkovalik42@gmail.com","ereh iztr wqqp eurz");
        smtp.Send(email);
        smtp.Disconnect(true);
        return Ok();



    }
   
    

  
}
