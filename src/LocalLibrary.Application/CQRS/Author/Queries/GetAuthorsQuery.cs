using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Queries
{
    public class GetAuthorsQuery : IRequest<IEnumerable<Domain.Models.Author>>
    {
    }
}
