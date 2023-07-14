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

    public User Add(User entity)
    {
        _userRepository.Add(entity);
        return entity;

    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public User Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }
}