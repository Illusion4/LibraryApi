namespace Library.Aplication.Dtos.BookDtos;

public class CreatingBookDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public decimal Rating { get; set; }
    
    public decimal ReviewsNumber { get; set; }
}