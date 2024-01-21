using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Queries
{
    public class GetLanguageQuery : IRequest<IEnumerable<Domain.Models.Language>>
    {
    }
}
