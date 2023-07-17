using Amazon.Lambda.Core;
using Application;
using Application.Commands.HelloWorldCommands;
using Infra;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Lambda;

public class Function
{
  readonly ServiceProvider _serviceProvider;
  private IConfigurationRoot Configuration;
  private IMediator _mediator;

  public Function(IMediator mediator)
  {
    BuildConfiguration();
    ConfigureServices();
    _mediator = mediator;
  }
 
  public async Task<HelloWorldResponse> FunctionHandler(HelloWorldRequest request, ILambdaContext context)
  {
    var response = await _mediator.Send(request);
    return response;
  }

  private void BuildConfiguration()
  {
    Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
  }

  private void ConfigureServices()
  {
    var services = new ServiceCollection();
    services.AddSqliteContext(Configuration);
    services.AddInfraData();
    services.AddApplication();
    services.BuildServiceProvider();
  }
}
