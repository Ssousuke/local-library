using AutoMapper;
using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Application.CQRS.Language.Commands;
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

            CreateMap<AuthorDTO, AuthorCreateCommand>().ReverseMap();
            CreateMap<AuthorDTO, AuthorRemoveCommand>().ReverseMap();
            CreateMap<AuthorDTO, AuthorUpdateCommand>().ReverseMap();

            CreateMap<BookDTO, BookCreateCommand>().ReverseMap();
            CreateMap<BookDTO, BookRemoveCommand>().ReverseMap();
            CreateMap<BookDTO, BookUpdateCommand>().ReverseMap();

            CreateMap<BookDTO, GenreCreateCommand>().ReverseMap();
            CreateMap<BookDTO, GenreRemoveCommand>().ReverseMap();
            CreateMap<BookDTO, GenreUpdateCommand>().ReverseMap();

            CreateMap<BookDTO, LanguageCreateCommand>().ReverseMap();
            CreateMap<BookDTO, LanguageRemoveCommand>().ReverseMap();
            CreateMap<BookDTO, LanguageUpdateCommand>().ReverseMap();
        }
    }
}
