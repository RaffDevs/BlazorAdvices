using BlazorAdvices.Data.Context;
using BlazorAdvices.Data.Entities;
using BlazorAdvices.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using BlazorAdvices.Data.Extensions;


namespace BlazorAdvices.Repositories;

public class AdvicesRepository
{
    private readonly BlazorAdviceDbContext _context;

    public AdvicesRepository(BlazorAdviceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Advice>> Get()
    {
        return await _context.Advices.ToListAsync();
    }

    public async Task<Advice?> GetBySlipCode(int slipCode)
    {
        return await _context.Advices.FirstOrDefaultAsync(adv => adv.SlipId == slipCode);
    }

    public async Task Create(AdviceDTO advice)
    {
        Console.WriteLine($"receveid id {advice.SlipId}");
        var checkAdvice = await GetBySlipCode(advice.SlipId);
        Console.WriteLine($"checked id {advice.SlipId}");

        if (checkAdvice is not null)
        {
            throw new Exception("This record has already favorite");
        }
        
        var entity = new Advice()
            .MapToAdvice(advice);

        await _context.Advices.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var advice = await _context.Advices.FirstOrDefaultAsync(adv => adv.SlipId == id);
        if (advice is null)
        {
            throw new Exception("No records found!");
        } 
        _context.Advices.Remove(advice);
        await _context.SaveChangesAsync();
    }
    
}