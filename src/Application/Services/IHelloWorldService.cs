using Domain.Entities;

namespace Domain.Interfaces.Services
{
  public interface IHelloWorldService
  {
    Task<string> CreateHello(HelloWorld hello);
  }
}