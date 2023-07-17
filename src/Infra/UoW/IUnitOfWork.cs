using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.UoW
{
  public interface IUnitOfWork : IDisposable
  {
    int Save();

  }
}
