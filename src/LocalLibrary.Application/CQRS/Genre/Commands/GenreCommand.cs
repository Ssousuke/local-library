using MediatR;

namespace LocalLibrary.Application.CQRS.Genre
{
    public abstract class GenreCommand : IRequest<Domain.Models.Genre>
    {
        public string Name { get; set; }
    }
}
