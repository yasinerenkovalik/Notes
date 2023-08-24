using System.Linq.Expressions;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Repository;

public interface INoteRepository:IGenericRepository<Note>
{
    List<Note> GetUserNotes(int id);
}