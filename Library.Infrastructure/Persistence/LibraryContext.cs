using Library.Aplication.Services;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence;

public class LibraryContext:DbContext, ILibraryDbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
        this.SeedData();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new RatingConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}

