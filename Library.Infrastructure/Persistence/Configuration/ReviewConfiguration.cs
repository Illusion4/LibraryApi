using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configuration;

public class ReviewConfiguration:IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasData(new List<Review>()
        {
            new Review()
            {
                Id = Guid.NewGuid(),
                BookId = Guid.Parse("e77cf2cb-3f3a-4f0b-ac5a-90a3263d075a"),
                Message = "Cool book",
                Reviewer = "Vasya"
            }
        });
    }
}