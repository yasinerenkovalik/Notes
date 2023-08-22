using Notes.Application.Repository;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Persistence.Repository;

public class ElasticSerchRepository:IElasticSearcRepository
{
    private ElaticContext _elaticContext;
    public ElasticSerchRepository(ElaticContext elaticContext)
    {
        _elaticContext = elaticContext;
    }
    public List<Note> GetAll()
    {
        var client = _elaticContext.Connection();
        var esResponse = client.Search<Note>().Documents;

        return esResponse.ToList();
    }

 

    public bool Add(Note note)
    {
        var client = _elaticContext.Connection();
       var result= client.IndexDocument(note);
       if (result.IsValid)
       {
           return true;
       }

       return false;
    }

    public bool Delete(int id)
    {
        var client = _elaticContext.Connection();
      var result=  client.DeleteByQuery<Emty>(p => p.Query(q1 => q1
            .Match(m => m
                .Field(f => f.UserId)
                .Query(id.ToString()
                )
            )));
      if (result.IsValid)
      {
          return true;
      }

      return false;

    }

    public bool Update(Note note)
    {
        var client = _elaticContext.Connection();
        var result= client.IndexDocument(note);
        if (result.IsValid)
        {
            return true;
        }

        return false;
    }

}