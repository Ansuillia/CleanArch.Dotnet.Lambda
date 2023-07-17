using Domain.Entities;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
  public class HelloWorldRepository : RepositoryBase<HelloWorld, Guid>
  {
    public HelloWorldRepository(AppDbContext context) : base(context)
    {
    }
  }
}
