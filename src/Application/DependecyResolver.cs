using Application.Commands.HelloWorldCommands;
using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
  public static class DependecyResolver
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

      return services;
    }
  }
}
