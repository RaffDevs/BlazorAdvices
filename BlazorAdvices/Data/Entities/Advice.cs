    using System.ComponentModel.DataAnnotations;

    namespace BlazorAdvices.Data.Entities;

    public class Advice
    {
        [Key]
        public int Id { get; set; }
        
        public string Content { get; set; }
        
        public int SlipId { get; set; }
    }