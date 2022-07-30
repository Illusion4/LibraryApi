using AutoMapper;
using Library.Aplication.Dtos.BookDtos;
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

    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
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
        var book = await _bookService.GetBookDetails(id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }
}