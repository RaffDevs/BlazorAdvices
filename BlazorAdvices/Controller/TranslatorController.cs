using BlazorAdvices.Models.DTOs;
using BlazorAdvices.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAdvices.Controller;

[Route("translate")]
[ApiController]
public class TranslatorController : ControllerBase
{
    private readonly TranslatorService _translatorService;

    public TranslatorController(TranslatorService translatorService)
    {
        _translatorService = translatorService;
    }

    [HttpPost]
    public async Task<IActionResult> Translate(AdviceDTO advice)
    {
        try
        {
            var result = await _translatorService.Translate(advice.Advice);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }
}