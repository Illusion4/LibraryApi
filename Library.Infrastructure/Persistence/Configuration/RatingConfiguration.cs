using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configuration;

public class RatingConfiguration:IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasData(new List<Rating>()
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
    }
}