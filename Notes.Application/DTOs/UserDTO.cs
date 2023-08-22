using Notes.Application;
using Notes.Domail;

namespace Notes.Persistence.DTOs;

public class UserDTO:BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; } 
    public string Role { get; set; }
  
}