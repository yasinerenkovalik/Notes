using System.Linq.Expressions;

namespace Notes.Application.Repository;

public interface IGenericRepository<T> where T:IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetAll(Expression<Func<T, bool>>? filter = null);
    T Get(Expression<Func<T, bool>> filter);

}