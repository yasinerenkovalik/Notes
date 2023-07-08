using System.Linq.Expressions;
using Notes.Application.Repository;
using Notes.Domail;

namespace Notes.Persistence.Repository;

public class UserService : IUserRepository
{
    private readonly Context _context;
    public UserService(Context context)
    {
        _context = context;
    }
    public void Add(User user)
    {
        var addedEntity = _context.Entry(User);
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public void Deleted(User user)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll(Expression<Func<User, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public User Get(Expression<Func<User, bool>> filter)
    {
        throw new NotImplementedException();
    }
}