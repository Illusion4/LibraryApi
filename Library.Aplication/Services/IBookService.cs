using Library.Aplication.Dtos.BookDtos;
using Library.Aplication.Dtos.RateDto;
using Library.Aplication.Dtos.ReviewDtos;
using Library.Aplication.Enums;
using Library.Domain.Entities;

namespace Library.Aplication.Services;

public interface IBookService
{
    public Task<List<BookDto>> GetBooksAsync(BooksOrderingParameter? orderBy = null);
    public Task<List<BookDto>> GetTopBooksAsync(BookGenreParameter? genre = null);
    public Task<BookDetailsDto> GetBookDetailsAsync(Guid id);
    public Task DeleteBookAsync(Guid id);
    public Task<Guid> UpsertBookAsync(CreatingBookDto bookDto);
    public Task<Guid> CreateReview(Guid bookId, CreatingReviewDto reviewDto);
    public Task CreateRate(Guid bookId, CreatingRateDto rateDto);
}