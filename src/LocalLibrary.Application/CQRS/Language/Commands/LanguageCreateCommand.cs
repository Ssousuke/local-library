using MediatR;

namespace LocalLibrary.Application.CQRS.Language.Commands
{
    public class LanguageCreateCommand : IRequest<Domain.Models.Language>
    {
        public string Name { get; set; }
    }
}
