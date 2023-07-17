using Domain.Interfaces.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
  public interface IRepository<T> 
    where T : IEntity
  {
    void Insert(T entity);
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
    T GetById<TId>(TId id) where TId : struct;
    void Update(T entity);
    void Delete<TId>(TId id) where TId : struct;
  }
}
