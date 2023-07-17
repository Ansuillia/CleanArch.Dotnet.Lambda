using Amazon.Lambda.Core;
using Application.Commands.HelloWorldCommands;
using MediatR;

namespace Lambda.UnitTests
{
  public class LambdaTests
  {

    [Fact]
    public void Lambda()
    {
      var input = new HelloWorldRequest("Jhon Dee");
      var context = A.Fake<ILambdaContext>();
      var fakeHandler = A.Fake<IMediator>();
      var function = new Function(fakeHandler);
      var response = function.FunctionHandler(input, context);
    }

  }
}