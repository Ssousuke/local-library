using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Queries
{
    public class GetLanguageByIdQuery : IRequest<Domain.Models.Language>
    {
        public GetLanguageByIdQuery(Guid languageId)
        {
            LanguageId = languageId;
        }

        public Guid LanguageId { get; set; }
    }
}
