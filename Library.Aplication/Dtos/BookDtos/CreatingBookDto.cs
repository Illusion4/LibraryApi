using System.ComponentModel.DataAnnotations;

namespace Library.Aplication.Dtos.BookDtos;

public class CreatingBookDto
{
    public Guid? Id { get; set; }
    
    public string Title { get; set; }
    
    public string Cover { get; set; }
    
    public string Content { get; set; }
    
    public string Genre { get; set; }
    
    public string Author { get; set; }
}