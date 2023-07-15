using System.Linq.Expressions;
using Notes.Application.Repository;
using Notes.Application.Services;
using Notes.Domail;

namespace Notes.Persistence.Services;

public class NoteService:INoteService
{
    private readonly INoteRepository noteService;
    public NoteService(INoteRepository _noteService)
    {
        noteService = _noteService;
    }
    public string Add(Note entity)
    {
       noteService.Add(entity);
        return "başarılı";
    }

    public string Update(Note entity)
    {
        noteService.Update(entity);
        return "result";
    }

    public string Delete(Note entity)
    {
        noteService.Deleted(entity);
        return "result";
    }

    public List<Note> GetAll()
    {
        var result = noteService.GetAll();
        return result;
    }

    public Note GetById(int id)
    {
        var result = noteService.Get(p => p.Id == id);
        return result;

    }

  
}