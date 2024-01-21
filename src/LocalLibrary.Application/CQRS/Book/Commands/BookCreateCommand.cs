using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Commands
{
    public class BookCreateCommand : IRequest<Domain.Models.Book>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
        public Guid LanguageId { get; set; }
    }
}
