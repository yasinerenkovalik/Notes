using System.Linq.Expressions;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Repository;
public interface IUserRepository:IGenericRepository<User>
{
    string Login(string mail, string password);
 
    
  
   
    
    


}