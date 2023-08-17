namespace Notes.Domail;

public class Note:BaseEntity
{
    public int UserId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool Done { get; set; }
    
    
}