using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Queries
{
    public class GetGenresQuery : IRequest<IEnumerable<Domain.Models.Genre>>
    {
    }
}
