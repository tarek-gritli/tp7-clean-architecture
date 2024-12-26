using AutoMapper;
using tp7.Application.DTOs;
using tp7.Domain.Entities;

namespace tp7.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<MovieReview, MovieReviewDTO>().ReverseMap();
        }
    }
}
