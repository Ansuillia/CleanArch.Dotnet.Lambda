using Domain.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
  public class HelloWorldService : IHelloWorldService
  {
    public async Task<string> CreateHello(HelloWorld hello)
    {
      await Task.Delay(3000);
      return hello.GetHello();
    }
  }
}
