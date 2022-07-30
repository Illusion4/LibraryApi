using System.Diagnostics;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Aplication.Dtos.BookDtos;
using Library.Aplication.Dtos.ReviewDtos;
using Library.Aplication.Enums;
using Library.Aplication.Extensions;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Aplication.Services;

public class BookService:IBookService
{
    private readonly ILibraryDbContext _libraryContext;
    private readonly IMapper _mapper;
    
    public BookService(ILibraryDbContext libraryContext, IMapper mapper)
    {
        _libraryContext = libraryContext;
        _mapper = mapper;
    }

    public Task<List<BookDto>> GetBooksAsync(BooksOrderingParameter? orderBy = null)
    {
        var query = _libraryContext.Books.AsQueryable()
            .GetOrderedBooks(orderBy);

        return _mapper.ProjectTo<BookDto>(query).ToListAsync();
    }

    public Task<List<BookDto>> GetTopBooksAsync(BookGenreParameter? genre = null)
    {
        var query = _libraryContext.Books.AsQueryable()
            .GetTopBooks(genre);

        return _mapper.ProjectTo<BookDto>(query).ToListAsync();
    }

    public Task<BookDetailsDto> GetBookDetails(Guid id)
    {
        var book = _libraryContext.Books.Select(b => new BookDetailsDto()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Content = b.Content,
            Cover = b.Cover,
            Rating = b.Ratings.Average(r => r.Score),
            Reviews = b.Reviews.Select(r => new ReviewDto()
            {
                Id = r.Id,
                Message = r.Message,
                Reviewer = r.Reviewer
            })
        }).FirstOrDefaultAsync(b=>b.Id == id);

        return book;
    }
}