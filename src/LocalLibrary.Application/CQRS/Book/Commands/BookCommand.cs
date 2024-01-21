using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Commands
{
    public abstract class BookCommand : IRequest<Domain.Models.Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
        public Guid LanguageId { get; set; }
    }
}
