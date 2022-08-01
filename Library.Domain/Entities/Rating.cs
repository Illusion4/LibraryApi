using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Rating
{
    public Guid Id { get; set; }
    
    public Guid BookId { get; set; }
    [Range(1,5)]
    public double Score { get; set; }
    
    public Book Book { get; set; }
}