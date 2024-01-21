using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Queries
{
    public class GetGenreByIdQuery : IRequest<Domain.Models.Genre>
    {
        public GetGenreByIdQuery(Guid genreId)
        {
            GenreId = genreId;
        }

        public Guid GenreId { get; set; }
    }
}
