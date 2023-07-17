using Domain.Entities;
using Domain.Interfaces.Services;
using MediatR;

namespace Application.Commands.HelloWorldCommands
{
  public class HelloWorldHandler : IRequestHandler<HelloWorldRequest, HelloWorldResponse>
  {
    private readonly IHelloWorldService _service;

    public HelloWorldHandler(IHelloWorldService service)
    {
      _service = service;
    }

    public async Task<HelloWorldResponse> Handle(HelloWorldRequest request, CancellationToken cancellationToken)
    {
      var hello = new HelloWorld(request.Name);

      var message = await _service.CreateHello(hello);

      return new HelloWorldResponse
      {
        Message = message
      };
    }
  }
}
