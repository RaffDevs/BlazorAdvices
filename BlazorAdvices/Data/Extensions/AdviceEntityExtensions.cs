using BlazorAdvices.Data.Entities;
using BlazorAdvices.Models.DTOs;

namespace BlazorAdvices.Data.Extensions;

public static class AdviceEntityExtensions
{
    public static Advice MapToAdvice(this Advice entity, AdviceDTO data)
    {
        return new Advice
        {
            Content = data.Advice,
            SlipId = data.SlipId
        };
    }       

    public static AdviceDTO MapToDTO(this Advice entity)
    {
        return new AdviceDTO
        {
            Advice = entity.Content,
            SlipId = entity.SlipId
        };
    }
}