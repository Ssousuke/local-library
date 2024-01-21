using LocalLibrary.Application.CQRS.Language.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Handler
{
    internal class LanguageCreateCommandHandler : IRequestHandler<LanguageCreateCommand, Domain.Models.Language>
    {
        private readonly IGenericRepository<Domain.Models.Language> _languageRepository;

        public LanguageCreateCommandHandler(IGenericRepository<Domain.Models.Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<Domain.Models.Language> Handle(LanguageCreateCommand request, CancellationToken cancellationToken)
        {
            var language = new Domain.Models.Language(request.Name);

            if (language is null)
                throw new ApplicationException($"Error could not be found.");
            return await _languageRepository.AddAsync(language);
        }
    }
}
