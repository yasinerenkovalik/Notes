namespace Notes.Domail;

public class User:BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public ICollection<Note>? Notes { get; set; }
    public bool Active { get; set; }
    public string Role { get; set; }
}