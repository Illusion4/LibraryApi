namespace Library.Aplication.Dtos.BookDtos;

public class BookDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public string Cover { get; set; }
    
    public double Rating { get; set; }
    
    public int ReviewsNumber { get; set; }
}