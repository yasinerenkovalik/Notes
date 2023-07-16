namespace Notes.Application.Services;

public interface IGenericService<T> where T  :IEntity
{
    string Add(T entity);
    string Update(T entity);
    string Delete(T entity);
    List<T> GetAll();
    T GetById(int id);
    

}