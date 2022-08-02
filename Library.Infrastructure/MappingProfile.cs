using AutoMapper;
using Library.Aplication.Dtos.BookDtos;
using Library.Aplication.Dtos.ReviewDtos;
using Library.Domain.Entities;

namespace Library.Infrastructure;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateProjection<Book, BookDto>()
            .ForMember(m => m.Rating, opt =>
                opt.MapFrom(b => b.Ratings.Count>0? b.Ratings.Average(r => r.Score) : default))
            .ForMember(m => m.ReviewsNumber,opt=>
                opt.MapFrom(b=>b.Reviews.Count));

        CreateProjection<Book, BookDetailsDto>()
            .ForMember(m => m.Rating, opt =>
                opt.MapFrom(b => b.Ratings.Count > 0 ? b.Ratings.Average(r => r.Score) : default))
            .ForMember(m => m.Reviews, opt =>
                opt.MapFrom(b => b.Reviews.Select(b => new ReviewDto()
                {
                    Id = b.Id,
                    Message = b.Message,
                    Reviewer = b.Reviewer
                })));
    }
}