using System.Linq.Expressions;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Repository;
public interface IUserRepository
{
    bool Add(User user);
    void Update(UserDTO user);
    void Deleted(User user);
    User GeyById(int id);
    string Login(string mail, string password);
 
    
    List<User> GetAll(Expression<Func<User, bool>>? filter = null);
    User Get(Expression<Func<User, bool>> filter);
    
    


}