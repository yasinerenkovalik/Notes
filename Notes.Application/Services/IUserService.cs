using Notes.Domail;

namespace Notes.Application.Services;

public interface IUserService:IGenericService<User>
{
    string Login(string email, string password);
    void SenMail(string mail);
}