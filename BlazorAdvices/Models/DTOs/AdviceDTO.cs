using System.Text.Json.Serialization;

namespace BlazorAdvices.Models.DTOs;

public record AdviceDTO
{
    [JsonPropertyName("id")]
    public int SlipId { get; init; }
    
    [JsonPropertyName("advice")]
    public string Advice { get; init; }
};

public record AdviceResponseDTO
{
    [JsonPropertyName("slip")]
    public AdviceDTO Advice { get; init; }
};