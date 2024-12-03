using BlazorAdvices.Models.DTOs;
using BlazorAdvices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAdvices.Controller;

[Route("ownadvices")]
[ApiController]
public class OwnerAdvicesController : ControllerBase
{
    private readonly OwnerAdvicesRepository _ownerAdvicesRepository;

    public OwnerAdvicesController(OwnerAdvicesRepository ownerAdvicesRepository)
    {
        _ownerAdvicesRepository = ownerAdvicesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var advices = await _ownerAdvicesRepository.Get();
            return Ok(advices);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });
        }
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OwnerAdviceDTO data)
    {
        try
        {
            await _ownerAdvicesRepository.Create(data);
            return Created();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] OwnerAdviceDTO data, int id)
    {
        try
        {
            await _ownerAdvicesRepository.Update(data, id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _ownerAdvicesRepository.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });
        }
    }
}