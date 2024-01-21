using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Handler
{
    public class GenreRemoveCommandHandler : IRequestHandler<GenreRemoveCommand, bool>
    {
        private readonly IGenericRepository<Domain.Models.Genre> _genreRepository;

        public GenreRemoveCommandHandler(IGenericRepository<Domain.Models.Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<bool> Handle(GenreRemoveCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.GenreId);
            if (genre is null)
                throw new ApplicationException($"Error could not be found.");
            return await _genreRepository.DeleteByIdAsync(genre.Id);
        }
    }
}
