using BlazorAdvices.Models.DTOs;

namespace BlazorAdvices.Components.State;

public class AdviceState
{
    public AdviceDTO? CurrentAdvice { get; set; }
    public List<AdviceDTO> FavoriteAdvices { get; set; } = [];
    public bool IsProcessing { get; set; }

    public void ToggleIsProcessing()
    {
        IsProcessing = !IsProcessing;
    }
}