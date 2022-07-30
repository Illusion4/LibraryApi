using Library.Aplication.Services;
using Library.Domain.Entities;

namespace Library.Infrastructure.Persistence;

public static class DbContextExtension
{
    public static void SeedData(this ILibraryDbContext? context)
    {
        
        context!.Books.AddRange(new List<Book>()
        {
            new Book()
            {
                Id = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Title = "Harry Potter and the Philosopher's Stone",
                Author = "Rowling",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Fantasy Fiction"
            }, 
            new Book()
            {
                Id = Guid.Parse("fd3c67c5-c6ff-4a5d-a166-98ece1b7752b"),
                Title = "The Hobbit",
                Author = "Tolkien",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Fantasy Fiction"
            }, 
            new Book()
            {
                Id = Guid.Parse("5b515247-f6f5-47e1-ad06-95f317a0599b"),
                Title = "Da Vinci Code",
                Author = "Dan Brown",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Thriller"
            }, 
            new Book()
            {
                Id = Guid.Parse("d942706b-e4e2-48f9-bbdc-b022816471f0"),
                Title = "The Great Gatsby",
                Author = "Scott Fitzgerald",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Tragedy",
            }, 
            new Book()
            {
                Id = Guid.Parse("2cd4b9a0-f70d-476d-a3cc-908da43f93c4"),
                Title = "Pinocchio",
                Author = "Carlo Collodi",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Fantasy Fiction",
            }, 
            new Book()
            {
                Id = Guid.Parse("5e7274ad-3132-4ad7-be36-38778a8f7b1c"),
                Title = "The Kite Runner",
                Author = "Khaled Hosseini",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Drama",
            }, 
            new Book()
            {
                Id = Guid.Parse("72a7a013-8bc4-4ae6-89cb-d9f19e0c9cf9"),
                Title = "To the Lighthouse",
                Author = "Virginia Woolf",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Fiction",
            }, 
            new Book()
            {
                Id = Guid.Parse("56d6294f-7b80-4a78-856a-92b141de2d1c"),
                Title = "In Search of Lost Time",
                Author = "Marcel Proust",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Philosophical fiction",
            }, 
            new Book()
            {
                Id = Guid.Parse("d1ae1de1-1aa8-4650-937c-4ed882038ad7"),
                Title = "The Book Thief",
                Author = "Markus Zusak",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Historical Fiction",
            }, 
            new Book()
            {
                Id = Guid.Parse("0dae5a74-3528-4e85-95bb-2036bd80432c"),
                Title = "Harry Potter and the Cursed Child",
                Author = "Rowling",
                Content = "Content of the book.",
                Cover = "Cover!",
                Genre = "Fantasy Fiction",
            }
        });
        context.Ratings.AddRange(new List<Rating>()
        {
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Score = 8
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("fd3c67c5-c6ff-4a5d-a166-98ece1b7752b"),
                Score = 7
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("5b515247-f6f5-47e1-ad06-95f317a0599b"),
                Score = 9
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("d942706b-e4e2-48f9-bbdc-b022816471f0"),
                Score = 6
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("2cd4b9a0-f70d-476d-a3cc-908da43f93c4"),
                Score = 6
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("5e7274ad-3132-4ad7-be36-38778a8f7b1c"),
                Score = 5
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("72a7a013-8bc4-4ae6-89cb-d9f19e0c9cf9"),
                Score = 8
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("56d6294f-7b80-4a78-856a-92b141de2d1c"),
                Score = 7
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("d1ae1de1-1aa8-4650-937c-4ed882038ad7"),
                Score = 9
            },
            new Rating()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("0dae5a74-3528-4e85-95bb-2036bd80432c"),
                Score = 8
            }
        });
        context.Reviews.AddRange(new List<Review>()
        {
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            },
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            }
        });

        context.SaveChangesAsync(CancellationToken.None);
    }
}