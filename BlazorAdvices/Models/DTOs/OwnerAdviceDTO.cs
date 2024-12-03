namespace BlazorAdvices.Models.DTOs;

public record OwnerAdviceDTO
{
    public string Advice { get; init; }
    public string Author { get; init; }
};