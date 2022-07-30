using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Aplication.Services;

public interface ILibraryDbContext
{
    public DbSet<Book> Books { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Rating> Ratings { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}