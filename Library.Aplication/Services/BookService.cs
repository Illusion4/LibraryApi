using System.Diagnostics;
using System.Net;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Aplication.Dtos.BookDtos;
using Library.Aplication.Dtos.RateDto;
using Library.Aplication.Dtos.ReviewDtos;
using Library.Aplication.Enums;
using Library.Aplication.Extensions;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
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

    public async Task<List<BookDto>> GetBooksAsync(BooksOrderingParameter? orderBy = null)
    {
        var query = _libraryContext.Books.AsQueryable()
            .GetOrderedBooks(orderBy);

        return await _mapper.ProjectTo<BookDto>(query).ToListAsync();
    }

    public async Task<List<BookDto>> GetTopBooksAsync(BookGenreParameter? genre = null)
    {
        var query = _libraryContext.Books.AsQueryable()
            .GetTopBooks(genre);

        return await _mapper.ProjectTo<BookDto>(query).ToListAsync();
    }

    public async Task<BookDetailsDto> GetBookDetailsAsync(Guid id)
    {
        var book = await _libraryContext.Books.Select(b => new BookDetailsDto()
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
        }).FirstOrDefaultAsync(b=>b.Id==id);

        if (book == null)
            throw new BookNotFoundException();

        return book;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await _libraryContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
            throw new BookNotFoundException();
            
        _libraryContext.Books.Remove(book);
        await _libraryContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<Guid> UpsertBookAsync(CreatingBookDto bookDto)
    {
        var book = new Book()
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            Content = bookDto.Content,
            Cover = bookDto.Cover,
            Genre = bookDto.Genre
        };
        if (bookDto.Id.HasValue)
            book.Id = bookDto.Id.Value;
        
        _libraryContext.Books.Update(book);
         await _libraryContext.SaveChangesAsync(CancellationToken.None);

         return book.Id;
    }

    public async Task<Guid> CreateReview(Guid bookId, CreatingReviewDto reviewDto)
    {
        var book = await _libraryContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);

        if (book == null)
            throw new BookNotFoundException();

        await _libraryContext.Reviews.AddAsync(new Review()
        {
            BookId = book.Id,
            Message = reviewDto.Message,
            Reviewer = reviewDto.Reviewer
        });
        await _libraryContext.SaveChangesAsync(CancellationToken.None);
        
        return book.Id;
    }

    public async Task CreateRate(Guid bookId, CreatingRateDto rateDto)
    {
        var book = await _libraryContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        if (book == null)
            throw new BookNotFoundException();

        await _libraryContext.Ratings.AddAsync(new Rating()
        {
            BookId = bookId,
            Score = rateDto.Score
        });
    }
    
}