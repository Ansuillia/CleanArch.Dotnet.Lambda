using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
  public class AppDbContext : DbContext, IAppDbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<HelloWorld>().HasKey(m => m.Id);
      base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<HelloWorld> HelloWorld { get; set; }
  }
}
