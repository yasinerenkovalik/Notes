using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Services;

public interface IUserService:IGenericService<User> 
{
    string Login(string email, string password);
    string Update(UserDTO user);


}