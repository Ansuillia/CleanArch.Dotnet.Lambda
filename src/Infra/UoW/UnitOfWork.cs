using Domain.Entities;
using Infra.Data.Context;
using Infra.Data.Repositories;

namespace Infra.Data.UoW
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
      _context = context;
    }

    private RepositoryBase<HelloWorld, Guid> _helloWordRepository;
    public RepositoryBase<HelloWorld, Guid> HelloWorldRepository => _helloWordRepository ?? new RepositoryBase<HelloWorld, Guid>(_context);

    public int Save()
    {
      return _context.SaveChanges();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
