using MediatR;

namespace Application.Commands.HelloWorldCommands
{
  public class HelloWorldRequest : IRequest<HelloWorldResponse>
  {
    public string Name { get; set; }

    public HelloWorldRequest(string name)
    {
      Name = name;
    }
  }
}
