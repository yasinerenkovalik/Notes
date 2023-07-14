namespace Notes.Application.Services;

public interface IGenericService<T> where T :IEntity
{
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
    List<T> GetAll();
    T GetById(int id);
}