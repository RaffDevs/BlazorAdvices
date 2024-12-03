using System.ComponentModel.DataAnnotations;

namespace BlazorAdvices.Data.Entities;

public class OwnerAdvice
{
    [Key]
    public int Id { get; set; }
    
    public string Advice { get; set; }
    
    public string Author { get; set; }
}