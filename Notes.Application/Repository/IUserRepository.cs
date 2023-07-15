using System.Linq.Expressions;
using Notes.Domail;

namespace Notes.Application.Repository;
public interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    void Deleted(User user);
    User GeyById(int id);
    bool Login(string mail, string password);

    List<User> GetAll(Expression<Func<User, bool>>? filter = null);
    User Get(Expression<Func<User, bool>> filter);
    
    


}