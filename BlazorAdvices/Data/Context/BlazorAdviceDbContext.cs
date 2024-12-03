using BlazorAdvices.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAdvices.Data.Context;

public class BlazorAdviceDbContext: DbContext
{
    public BlazorAdviceDbContext(DbContextOptions<BlazorAdviceDbContext> options): base(options) {}
    
    public DbSet<Advice> Advices { get; set; }
    
    public DbSet<OwnerAdvice> OwnerAdvices { get; set; }
}