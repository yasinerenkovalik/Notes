namespace Notes.Domail;

public class User:BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Code { get; set; }
    public bool Active { get; set; } 
    public string Role { get; set; } 
}