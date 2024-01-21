using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Commands
{
    public abstract class AuthorCommand : IRequest<Domain.Models.Author>
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime? DateOfDeath { get; private set; }
    }
}
