using LocalLibrary.Application.CQRS.Language.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Handler
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguageQuery, IEnumerable<Domain.Models.Language>>
    {
        private readonly IGenericRepository<Domain.Models.Language> _languageRepository;

        public GetLanguagesQueryHandler(IGenericRepository<Domain.Models.Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IEnumerable<Domain.Models.Language>> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            return await _languageRepository.GetAll();
        }
    }
}
