using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Commands
{
    public abstract class GenreCommand : IRequest<Domain.Models.Genre>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
