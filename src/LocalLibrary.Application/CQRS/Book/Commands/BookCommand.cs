using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Commands
{
    public abstract class BookCommand : IRequest<Domain.Models.Book>
    {
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string ISBN { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid GenreId { get; private set; }
        public Guid LanguageId { get; private set; }
    }
}
