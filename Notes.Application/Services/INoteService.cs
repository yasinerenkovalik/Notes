using Notes.Application.Repository;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Services;

public interface INoteService:IGenericService<Note>
{
    List<Note> UserNotes(int id);
    string Update(UserDTO userDto);
}