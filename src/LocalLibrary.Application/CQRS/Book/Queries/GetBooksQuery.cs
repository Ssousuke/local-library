using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<Domain.Models.Book>>
    {
    }
}
