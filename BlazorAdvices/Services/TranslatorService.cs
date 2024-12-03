using System.Web;
using BlazorAdvices.Models.DTOs;

namespace BlazorAdvices.Services;

public class TranslatorService
{
    private readonly IConfiguration _configuration;

    public TranslatorService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<TranslationDTO> Translate(string text)
    {
        var uriBuilder = new UriBuilder(_configuration.GetSection("Api")["Translator"])
        {
            Scheme = "https",
            Path = "translate"
        };

        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["api-version"] = "3.0";
        query["from"] = "en";
        query["to"] = "pt-br";
        uriBuilder.Query = query.ToString();
        var uri = uriBuilder.Uri;

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["Key:Translator"]);
        httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region","brazilsouth");
        var body = new List<TranslateRequestDTO>
        {
            new TranslateRequestDTO { Text = text }
        };
        var request = await httpClient.PostAsJsonAsync(uri, body);
        if (request.IsSuccessStatusCode)
        {
            var content = await request.Content.ReadFromJsonAsync<List<TranslateResponseDTO>>();
            return content.First().Translations.First();
        }

        throw new Exception("Translation error");
    }
}