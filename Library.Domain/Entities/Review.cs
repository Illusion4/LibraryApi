namespace Library.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    
    public string Message { get; set; }
    
    public Guid BookId { get; set; }
    
    public string Reviewer { get; set; }
    
    public Book Book { get; set; }
}