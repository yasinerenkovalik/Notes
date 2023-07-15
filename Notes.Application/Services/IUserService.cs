using Notes.Domail;

namespace Notes.Application.Services;

public interface IUserService:IGenericService<User>
{
    bool Login(string email, string password);
}