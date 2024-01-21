using LocalLibrary.Application.CQRS.Language.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Handler
{
    public class GetLanguageByIdQueryHandler : IRequestHandler<GetLanguageByIdQuery, Domain.Models.Language>
    {
        private readonly IGenericRepository<Domain.Models.Language> _languageRepository;

        public GetLanguageByIdQueryHandler(IGenericRepository<Domain.Models.Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<Domain.Models.Language> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
        {
            return await _languageRepository.GetByIdAsync(request.LanguageId);
        }
    }
}
