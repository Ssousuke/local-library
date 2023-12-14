using AutoMapper;
using LocalLibrary.Application.DTO;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Application.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<Language, LanguageDTO>().ReverseMap();
        }
    }
}
