using System.Net.Http.Headers;
using GitHubClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host#host-shutdown

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddLogging(logging => logging.AddSimpleConsole(options => options.SingleLine = true));
        services.AddHostedService<Application>();
        services.AddHttpClient<ApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ssz", "1.0"));
        });
    })
    .Build();

await host.RunAsync();