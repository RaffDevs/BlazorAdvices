using System.Text.Json.Serialization;

namespace BlazorAdvices.Models.DTOs;

public record TranslateResponseDTO
{
    [JsonPropertyName("translations")]
    public List<TranslationDTO> Translations { get; init; }
}

public record TranslationDTO
{
    [JsonPropertyName("text")]
    public string Text { get; init; }
    
    [JsonPropertyName("to")]
    public string To { get; init; }
}

public record TranslateRequestDTO
{
    [JsonPropertyName("text")]
    public string Text { get; init; }
}