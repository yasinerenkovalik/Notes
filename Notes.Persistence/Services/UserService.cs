using Notes.Application.Repository;
using Notes.Application.Services;
using Notes.Domail;
using Notes.Persistence.DTOs;

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
        var user= _userRepository.Add(entity);
        if (user == true)
        {
            return "Kayıt İşlemi Bşarılı";
        }

        return "Böyle bir kullanıcı bulunmaktadır";

    }

    public string Update(User entity)
    {
        throw new NotImplementedException();
    }

    public string Update(UserDTO entity)
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

    public string Login(string email, string password)
    {
        var result = _userRepository.Login(email, password);
        if (result != null)
        {
            return result;
        }

        return "kullanıcı bulunamadı";
    }

    public void SenMail(string mail)
    {
        throw new NotImplementedException();
    }
}