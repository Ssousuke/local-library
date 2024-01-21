using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Commands
{
    public class GenreCreateCommand : IRequest<Domain.Models.Genre>
    {
        public string Name { get; set; }
    }
}
