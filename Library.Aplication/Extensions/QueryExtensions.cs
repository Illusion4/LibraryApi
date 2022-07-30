using Library.Aplication.Enums;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Aplication.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Book> GetOrderedBooks(this IQueryable<Book> query,
        BooksOrderingParameter? order = null) => order switch
    {
        BooksOrderingParameter.Author => query.OrderBy(b=>b.Author),
        BooksOrderingParameter.Title => query.OrderBy(b=>b.Title),
        BooksOrderingParameter.Rating => query.OrderBy(b=>b.Ratings.Average(r=>r.Score)),
        _ => query
    };

    public static IQueryable<Book> GetTopBooks(this IQueryable<Book> query,
        BookGenreParameter? genre = null) => genre.HasValue switch
    {
        true => query.Where(b=>b.Genre == genre.ToString())
            .GetOrderedBooks(BooksOrderingParameter.Rating)
            .Where(b => b.Reviews.Count > 10)
            .Take(10),
        
        false => query.GetOrderedBooks(BooksOrderingParameter.Rating)
            .Where(b=>b.Reviews.Count>10)
            .Take(10)
    };
}