using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using Notes.Application.Repository;
using Notes.Domail;
using Claim = System.Security.Claims.Claim;
using JwtSecurityToken = System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

namespace Notes.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly Context _context;
    public UserRepository(Context context)
    {
        _context = context;
    }


    public bool Add(User user)
    {
        var login= _context.Set<User>().Where(n => n.Email == user.Email ).FirstOrDefault();
        if (login == null)
        {
            var randomGenerator = new Random();
            var random1 = randomGenerator.Next(100000, 999999);
            Console.WriteLine(random1);
          
            user.Code = random1.ToString();
            MailSend(user.Email,user.Code);
            user.CreatedDate=DateTime.UtcNow;
            var addedEntity = _context.Entry(user);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
            return true;
        }
        return false;
    }

    public void Update(User entity)
    {
        var addedEntity = _context.Entry(entity);
        addedEntity.State = EntityState.Modified;
        _context.SaveChanges();
        addedEntity.State = EntityState.Detached;
    }

    public void Delete(User entity)
    {
        var addedEntity = _context.Entry(entity);
        addedEntity.State = EntityState.Deleted;
        _context.SaveChanges();
        addedEntity.State = EntityState.Detached;
    }
    public string Login(string mail, string password)
    {
       var login= _context.Set<User>().Where(n => n.Email == mail && n.Password == password).FirstOrDefault();
       if (login != null)
       {
           var claims = new[]
           {
               new Claim(JwtRegisteredClaimNames.NameId,login.Id.ToString()),
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
       
       return null;
    }

    public void MailSend(string mail,string code)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("erenkovalik@gmail.com"));
        email.To.Add(MailboxAddress.Parse(mail));
        email.Subject = "test mail";
        email.Body = new TextPart(TextFormat.Html) { Text = code };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com",587,SecureSocketOptions.StartTls);
        smtp.Authenticate("erenkovalik@gmail.com","ereh iztr wqqp eurz");
        smtp.Send(email);
        smtp.Disconnect(true);
        
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

    public User GetById(int id)
    {
        return _context.Set<User>().FirstOrDefault(n => n.Id == id);
    }
}
