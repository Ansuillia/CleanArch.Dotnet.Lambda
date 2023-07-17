using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Data.Repositories
{
  public class RepositoryBase<T, TId> : IRepository<T>
    where TId : struct
    where T : EntityBase<TId> 
  {
    internal AppDbContext _context;
    internal DbSet<T> _dbSet;

    public RepositoryBase(AppDbContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, string includeProperties = "")
    {
      IQueryable<T> query = _dbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split
          (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (orderBy != null)
      {
        return orderBy(query).ToList();
      }
      else
      {
        return query.ToList();
      }
    }

    public virtual T GetById<TId>(TId id) where TId : struct
    {
      return _dbSet.Find(id);
    }

    public virtual void Insert(T entity)
    {
      _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
      _dbSet.Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Delete<TId>(TId id) where TId : struct
    {
      T entityToDelete = _dbSet.Find(id);
      if (entityToDelete != null)
      {
        Delete(entityToDelete);
      }
    }

    public virtual void Delete(T entityToDelete)
    {
      if (_context.Entry(entityToDelete).State == EntityState.Detached)
      {
        _dbSet.Attach(entityToDelete);
      }
      _dbSet.Remove(entityToDelete);
    }


    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    #endregion
  }
}
