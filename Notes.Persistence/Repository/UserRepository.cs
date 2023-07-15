using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
       var login= _context.Set<User>().FirstOrDefault(n => n.Email == mail && n.PhoneNumber == password);
       if (login!=null)
       {
           return "başarılı";
       }

       return "giriş başarısız";
    }

    public List<User> GetAll(Expression<Func<User, bool>>? filter = null)
    {
        return filter == null ? _context.Set<User>().ToList() :
            _context.Set<User>().Where(filter).ToList();
    }

    public User Get(Expression<Func<User, bool>> filter)
    {
        return _context.Set<User>().FirstOrDefault(filter) ?? throw new InvalidOperationException();
    }

  

   

  
}