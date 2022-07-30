using Library.Aplication.Dtos.ReviewDtos;
using Library.Domain.Entities;

namespace Library.Aplication.Dtos.BookDtos;

public class BookDetailsDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public string Cover { get; set; }
    
    public string Content { get; set; }
    public double Rating { get; set; }
    
    public IEnumerable<ReviewDto> Reviews { get; set; }
}