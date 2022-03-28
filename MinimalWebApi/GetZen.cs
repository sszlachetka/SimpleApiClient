namespace MinimalWebApi;

internal static class GetZen
{
    public static void MapGetZen(this WebApplication app)
    {
        app.MapGet("/zen", async(ApiClient apiClient, ILogger<Program> logger, string? name) =>
            {
                logger.LogInformation("Handling zen for '{Name}'", name);

                var phrase = await apiClient.GetZen();

                return string.IsNullOrWhiteSpace(name) ? phrase : $"{name.Trim()} {phrase}";
            })
            .WithName("GetZen");
    }
}