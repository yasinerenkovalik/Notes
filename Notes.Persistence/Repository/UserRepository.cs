using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Repository;
using Notes.Domail;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MailKit.Security;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MimeKit;
using MimeKit.Text;

using JwtSecurityToken = System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

namespace Notes.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly Context _context;
    public UserRepository(Context context)
    {
        _context = context;
    }
    public void Add(User user)
    {
        var addedEntity = _context.Entry(user);
        addedEntity.State = EntityState.Added;
        _context.SaveChanges();
        addedEntity.State = EntityState.Detached;

    }

    public void Update(User user)
    {
        var addedEntity = _context.Entry(user);
        addedEntity.State = EntityState.Modified;
        _context.SaveChanges();
        addedEntity.State = EntityState.Detached;
    }

    public void Deleted(User user)
    {
        var addedEntity = _context.Entry(user);
        addedEntity.State = EntityState.Deleted;
        _context.SaveChanges();
        addedEntity.State = EntityState.Detached;
    }

    public User GeyById(int id)
    {
        return _context.Set<User>().FirstOrDefault(n => n.Id == id);
    }

    public string Login(string mail, string password)
    {
       
        var login= _context.Set<User>().Where(n => n.Email == mail && n.Password == password).FirstOrDefault();
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.Name),
            new Claim(ClaimTypes.Surname,login.SurName ),
            new Claim(ClaimTypes.Email,login.Email),
            new Claim(ClaimTypes.MobilePhone,login.PhoneNumber),
            new Claim(ClaimTypes.Role,login.Role),
            new Claim(JwtRegisteredClaimNames.Email, mail)
        };
        var singninKey = "bubenimsigninkeyim";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(singninKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer:"http://www.yasineren.com",
            audience:"mysecuritykey",
            claims:claims,
            expires:DateTime.Now.AddDays(15),
            notBefore:DateTime.Now,
            signingCredentials:credentials
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
       
        return token;
    }

    public void MailSend(string mail)
    {
        try
        {
            // Mail göndermek için SMTP istemcisini yapılandırma
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("erenkovalik42@gmail.com", "Sifre.3442");

            // Mail mesajını oluşturma
            MailMessage message = new MailMessage();
            message.From = new MailAddress("erenkovalik42@gmail.com");
            message.To.Add("avcikiz25@gmail.com");
            message.Subject = "Merhaba!";
            message.Body = "Bu bir test e-postasıdır.";

            // Mail'i gönderme
            client.Send(message);

            Console.WriteLine("E-posta gönderildi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata oluştu: " + ex.Message);
        }
    }

    public string MailSend(string mail)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("avcikiz25@gmail.com"));
        email.To.Add(MailboxAddress.Parse("erenkovalik42@gmail.com"));
        email.Subject = "test mail";
        email.Body = new TextPart(TextFormat.Html) { Text = "merhabalarr" };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com",587,SecureSocketOptions.StartTls);
        smtp.Authenticate("avcikiz25@gmail.com","ereh iztr wqqp eurz");
        smtp.Send(mail);
        smtp.Disconnect(true);
        return Ok();
    }
    

  

    public List<User> GetAll(Expression<Func<User, bool>>? filter = null)
    {
        return filter == null ? _context.Set<User>().ToList() :
            _context.Set<User>().Where(filter).ToList();
    }

    public User Get(Expression<Func<User, bool>> filter)
    {
        return _context.Set<User>().FirstOrDefault(filter);
    }

  

   

  
}