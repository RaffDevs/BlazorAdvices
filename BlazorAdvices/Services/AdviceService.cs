using BlazorAdvices.Models.DTOs;

namespace BlazorAdvices.Services;

public class AdviceService
{
    private readonly IConfiguration _configuration;

    public AdviceService( IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<AdviceDTO?> GetRandomAdvice()
    {
        var uriBuilder = new UriBuilder(_configuration.GetSection("Api")["Advice"])
        {
            Path = "advice",
            Scheme = "https"
        };
        var httpClient = new HttpClient();

        var uri = uriBuilder.Uri;
        
        var response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<AdviceResponseDTO>();
        return content?.Advice;
    }
}