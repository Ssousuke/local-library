using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Commands
{
    public class LanguageRemoveCommand : IRequest<bool>
    {
        public LanguageRemoveCommand(Guid languageId)
        {
            LanguageId = languageId;
        }

        public Guid LanguageId { get; set; }
    }
}
