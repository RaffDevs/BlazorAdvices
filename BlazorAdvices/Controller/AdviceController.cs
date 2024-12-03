using BlazorAdvices.Models.DTOs;
using BlazorAdvices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAdvices.Controller;

[Route("advice")]
[ApiController]
public class AdviceController : ControllerBase
{
    private readonly AdvicesRepository _repository;

    public AdviceController(AdvicesRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var advices = await _repository.Get();
            return Ok(advices);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdviceDTO data)
    {
        try
        {
            await _repository.Create(data);
            return Created();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _repository.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}