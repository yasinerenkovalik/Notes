using Notes.Application;

namespace Notes.Domail;

public class BaseEntity:IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
}