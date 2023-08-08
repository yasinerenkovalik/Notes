using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Notes.Application.Repository;
using Notes.Domail;

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
       var login= _context.Set<User>().Where(n => n.Email == mail && n.PhoneNumber == password).FirstOrDefault();
       if (login != null)
       {
           var claims = new[]
           {
               new Claim(ClaimTypes.Name, mail),
               new Claim(ClaimTypes.Country, "turkey"),
                
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

       
       
       return null;
    }

    public void MailSend(string mail)
    {
        throw new NotImplementedException();
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