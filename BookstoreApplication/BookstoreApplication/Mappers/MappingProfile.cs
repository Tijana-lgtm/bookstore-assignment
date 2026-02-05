using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.YearsSincePublished, opt => opt.MapFrom(src => DateTime.Now.Year - src.PublishedDate.Year))
                .ReverseMap();

            CreateMap<Book, BookDetailsDTO>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.Publisher.Id))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ReverseMap();

            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
