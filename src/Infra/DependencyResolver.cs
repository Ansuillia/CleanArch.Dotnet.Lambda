using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
  public static class DependencyResolver
  {
    public static IServiceCollection AddInfraData(this IServiceCollection services)
    {
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      return services.AddTransient<IRepository<HelloWorld>, RepositoryBase<HelloWorld, Guid>>();
    }

    public static IServiceCollection AddSqliteContext(this IServiceCollection services, IConfiguration Configuration)
    {
      var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];

      return services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite(connection));
    }
  }
}
