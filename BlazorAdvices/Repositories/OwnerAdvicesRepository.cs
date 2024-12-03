using BlazorAdvices.Data.Context;
using BlazorAdvices.Data.Entities;
using BlazorAdvices.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlazorAdvices.Repositories;

public class OwnerAdvicesRepository
{
    private readonly BlazorAdviceDbContext _context;

    public OwnerAdvicesRepository(BlazorAdviceDbContext context)
    {
        _context = context;
    }

    public async Task<List<OwnerAdvice>> Get()
    {
        return await _context.OwnerAdvices.ToListAsync();
    }

    public async Task<OwnerAdvice?> GetById(int id)
    {
        var ownerAdvice = await _context.OwnerAdvices.FindAsync(id);

        if (ownerAdvice is null)
        {
            throw new Exception("No records has been found");
        }

        return ownerAdvice;
    }

    public async Task Create(OwnerAdviceDTO data)
    {
        var ownerAdvice = new OwnerAdvice
        {
            Advice = data.Advice,
            Author = data.Author
        };

        _context.OwnerAdvices.Add(ownerAdvice);
        await _context.SaveChangesAsync();
    }

    public async Task Update(OwnerAdviceDTO data, int id)
    {
        var ownerAdvice = await GetById(id);
        ownerAdvice.Advice = data.Advice;
        ownerAdvice.Author = data.Author;

        _context.OwnerAdvices.Update(ownerAdvice);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var ownerAdvice = await GetById(id);
        _context.OwnerAdvices.Remove(ownerAdvice);
       await _context.SaveChangesAsync();
    }
}