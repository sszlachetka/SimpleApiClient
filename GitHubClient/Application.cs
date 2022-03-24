using Microsoft.Extensions.Hosting;

namespace GitHubClient;

public class Application : IHostedService
{
    private readonly IHostApplicationLifetime _hostLifetime;
    private readonly ApiClient _apiClient;

    public Application(IHostApplicationLifetime hostLifetime, ApiClient apiClient)
    {
        _hostLifetime = hostLifetime;
        _apiClient = apiClient;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _apiClient.LogZen();

        _hostLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}