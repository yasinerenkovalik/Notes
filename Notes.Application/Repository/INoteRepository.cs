using System.Linq.Expressions;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Repository;

public interface INoteRepository
{
    void Add(Note note);
    void Update(Note note);
    void Deleted(Note note);

    List<Note> GetAll(Expression<Func<Note, bool>>? filter = null);
    Note? Get(Expression<Func<Note?, bool>> filter);

    List<Note> GetUserNotes(int id);
}