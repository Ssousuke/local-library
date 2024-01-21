using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Commands
{
    public class AuthorCreateCommand : IRequest<Domain.Models.Author>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}
