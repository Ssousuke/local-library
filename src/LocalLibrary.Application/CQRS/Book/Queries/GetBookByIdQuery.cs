using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Queries
{
    public class GetBookByIdQuery : IRequest<Domain.Models.Book>
    {
        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; set; }

    }
}
