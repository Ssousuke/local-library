using LocalLibrary.Application.CQRS.Language.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Handler
{
    public class LanguageRemoveCommandHandler : IRequestHandler<LanguageRemoveCommand, bool>
    {
        private readonly IGenericRepository<Domain.Models.Language> _languageRepository;

        public LanguageRemoveCommandHandler(IGenericRepository<Domain.Models.Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<bool> Handle(LanguageRemoveCommand request, CancellationToken cancellationToken)
        {
            var language = await _languageRepository.GetByIdAsync(request.LanguageId);
            if (language == null)
                throw new ApplicationException($"Error could not be found.");
            return await _languageRepository.DeleteByIdAsync(language.Id);
        }
    }
}
