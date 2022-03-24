using Microsoft.Extensions.Logging;

namespace GitHubClient;

// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiClient> _logger;

    public ApiClient(HttpClient httpClient, ILogger<ApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task LogZen()
    {
        var response = await _httpClient.GetStringAsync("zen");
        
        _logger.LogInformation("Zen: {Response}", response);
    }
}