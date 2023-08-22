using System.Linq.Expressions;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Application.Repository;

public interface IElasticSearcRepository
{
    List<Note> GetAll();
    bool Add(Note note);
    bool Delete(int id);
    bool Update(Note note);
    
}