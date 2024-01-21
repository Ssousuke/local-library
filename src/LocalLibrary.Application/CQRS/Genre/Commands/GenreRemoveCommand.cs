using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Commands
{
    public class GenreRemoveCommand : IRequest<bool>
    {
        public GenreRemoveCommand(Guid genreId)
        {
            GenreId = genreId;
        }

        public Guid GenreId { get; set; }
    }
}
