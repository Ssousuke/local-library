using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Commands
{
    public abstract class LanguageCommand : IRequest<Domain.Models.Language>
    {
        public string Name { get; set; }
    }
}
