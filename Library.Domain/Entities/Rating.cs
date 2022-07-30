namespace Library.Domain.Entities;

public class Rating
{
    public Guid Id { get; set; }
    
    public Guid BookId { get; set; }
    
    public int Score { get; set; }
    
    public Book Book { get; set; }
}