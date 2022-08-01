namespace Library.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Cover { get; set; }
    
    public string? Content { get; set; }
    
    public string? Author { get; set; }
    
    public string? Genre { get; set; }
    
    public ICollection<Rating> Ratings { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
}