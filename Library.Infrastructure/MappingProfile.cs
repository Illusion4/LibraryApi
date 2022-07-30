using AutoMapper;
using Library.Aplication.Dtos.BookDtos;
using Library.Domain.Entities;

namespace Library.Infrastructure;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateProjection<Book, BookDto>()
            .ForMember(m => m.Rating, opt =>
                opt.MapFrom(b => b.Ratings.Average(b => b.Score)))
            .ForMember(m => m.ReviewsNumber,opt=>
                opt.MapFrom(b=>b.Reviews.Count));
        
    }
}