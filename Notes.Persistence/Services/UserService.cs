using System.Linq.Expressions;
using Notes.Application.Repository;
using Notes.Application.Services;
using Notes.Domail;

namespace Notes.Persistence.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public string Add(User entity)
    {
        _userRepository.Add(entity);
        return "entity";

    }

    public string Update(User entity)
    {
        _userRepository.Update(entity);
        return "entity";
    }

    public string Delete(User entity)
    {
        _userRepository.Deleted(entity);
        return "entity";
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User GetById(int id)
    {
        return _userRepository.GeyById(id) ?? throw new InvalidOperationException();
    }

    public bool Login(string email, string password)
    {
        var result = _userRepository.Login(email, password);
        if (result !=null)
        {
            return true;
        }

        return false;
    }
}