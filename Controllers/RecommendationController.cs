using Library.Aplication.Enums;
using Library.Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/recommended")]
public class RecommendationController:ControllerBase
{
    private readonly IBookService _bookService;
    
    public RecommendationController(IBookService service, IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery(Name = "genre")]BookGenreParameter? genre)
    {
        var books = await _bookService.GetTopBooksAsync(genre);

        if (books.Count == 0)
            return NotFound();

        return Ok(books);
    }
}