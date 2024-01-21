using LocalLibrary.Application.CQRS.Language.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Handler
{
    public class LanguageUpdateCommandHandler : IRequestHandler<LanguageUpdateCommand, Domain.Models.Language>
    {
        private readonly IGenericRepository<Domain.Models.Language> _languageRepository;

        public LanguageUpdateCommandHandler(IGenericRepository<Domain.Models.Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<Domain.Models.Language> Handle(LanguageUpdateCommand request, CancellationToken cancellationToken)
        {
            var language = new Domain.Models.Language(request.LanguageId, request.Name);

            if (language is null)
                throw new ApplicationException($"Error could not be found.");
            return await _languageRepository.UpdateAsync(language);
        }
    }
}
