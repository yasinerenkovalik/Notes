using System.Linq.Expressions;
using Notes.Domail;

namespace Notes.Application;

public interface INoteService
{
    void Add(Note note);
    void Update(Note note);
    void Deleted(Note not);

    List<Note> GetAll(Expression<Func<Note,bool>>? filter=null);
    Note Get(Expression<Func<Note,bool>> filter);
}