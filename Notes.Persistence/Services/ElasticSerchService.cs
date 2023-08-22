using Notes.Application.Repository;
using Notes.Application.Services;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Persistence.Services;

public class ElasticSerchService:IElasticSearcService
{
    private IElasticSearcRepository _elasticSearcRepository;

    public ElasticSerchService(IElasticSearcRepository elasticSearcRepository)
    {
        _elasticSearcRepository = elasticSearcRepository;
    }
    public string Add(Note note)
    {
        var result = _elasticSearcRepository.Add(note);
        if (result)
        {
            return "true";
        }
        return "false";
    }

    public string Delete(Note entity)
    {
        var result = _elasticSearcRepository.Delete(entity.UserId);
        if (result)
        {
            return "basarılı";
        }

        return "olmadı";
    }

    public List<Note> GetAll()
    {
      return _elasticSearcRepository.GetAll();
        
    }

    public Note GetById(int id)
    {
        throw new NotImplementedException();
    }
}