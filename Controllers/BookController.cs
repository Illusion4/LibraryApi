using AutoMapper;
using Library.Aplication.Dtos.BookDtos;
using Library.Aplication.Dtos.RateDto;
using Library.Aplication.Dtos.ReviewDtos;
using Library.Aplication.Enums;
using Library.Aplication.Services;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/books")]
public class BookController:ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IConfiguration _configuration;
    
    
    public BookController(IBookService bookService, IConfiguration configuration)
    {
        _bookService = bookService;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery(Name = "order")] BooksOrderingParameter? order)
    {
        var books = await _bookService.GetBooksAsync(order);
        if (books.Count == 0)
            return NotFound();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book = await _bookService.GetBookDetailsAsync(id);

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromQuery]string secret)
    {
        if (_configuration["AppSecret"] != secret)
        {
            return BadRequest();
        }

        await _bookService.DeleteBookAsync(id);

        return NoContent();
    }

    [HttpPost("save")]
    public async Task<IActionResult> UpsertBook([FromBody]CreatingBookDto bookDto)
    {
        var bookId = await _bookService.UpsertBookAsync(bookDto);
        return Ok(new {Id = bookId });
    }

    [HttpPost("{id}/review")]
    public async Task<IActionResult> CreateReview(Guid id, CreatingReviewDto reviewDto)
    {
        var reviewId = await _bookService.CreateReview(id, reviewDto);

        return Ok(new { Id = reviewId });
    }

    [HttpPost("{id}/rate")]
    public async Task<IActionResult> CreateRate(Guid id, CreatingRateDto rateDto)
    {
        await _bookService.CreateRate(id, rateDto);

        return NoContent();
    }
}