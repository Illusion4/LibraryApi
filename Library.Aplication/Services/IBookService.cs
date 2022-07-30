using Library.Aplication.Dtos.BookDtos;
using Library.Aplication.Enums;
using Library.Domain.Entities;

namespace Library.Aplication.Services;

public interface IBookService
{
    public Task<List<BookDto>> GetBooksAsync(BooksOrderingParameter? orderBy = null);
    public Task<List<BookDto>> GetTopBooksAsync(BookGenreParameter? genre = null);

    public Task<BookDetailsDto> GetBookDetails(Guid id);
}