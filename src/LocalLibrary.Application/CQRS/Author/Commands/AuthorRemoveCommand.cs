using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Commands
{
    public class AuthorRemoveCommand : IRequest<bool>
    {
        public Guid AuhtorId { get; set; }
        public AuthorRemoveCommand(Guid AuthorId)
        {
            AuhtorId = AuthorId;
        }
    }
}
