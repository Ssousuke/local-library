using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Handler
{
    public class GenreUpdateCommandHandler : IRequestHandler<GenreUpdateCommand, Domain.Models.Genre>
    {
        private readonly IGenericRepository<Domain.Models.Genre> _genreRepository;

        public GenreUpdateCommandHandler(IGenericRepository<Domain.Models.Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Domain.Models.Genre> Handle(GenreUpdateCommand request, CancellationToken cancellationToken)
        {
            var genre = new Domain.Models.Genre(request.GenreId, request.Name);

            if (genre is null)
                throw new ApplicationException($"Error could not be found.");
            return await _genreRepository.UpdateAsync(genre);
        }
    }
}
