using Notes.Application;

namespace Notes.Persistence.DTOs;

public class Emty:IEntity
{
    public string Text { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
}