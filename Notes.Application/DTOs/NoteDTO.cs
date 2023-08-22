using System.Reflection;
using Notes.Application;
using Notes.Domail;

namespace Notes.Persistence.DTOs;

public class NoteDTO:BaseEntity
{
    
    public string Title { get; set; }
    public string Text { get; set; }
    public bool Done { get; set; }
}