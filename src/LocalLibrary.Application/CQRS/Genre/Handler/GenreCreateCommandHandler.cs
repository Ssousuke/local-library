using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Handler
{
    public class GenreCreateCommandHandler : IRequestHandler<GenreCreateCommand, Domain.Models.Genre>
    {
        private readonly IGenericRepository<Domain.Models.Genre> _genreRepository;

        public GenreCreateCommandHandler(IGenericRepository<Domain.Models.Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Domain.Models.Genre> Handle(GenreCreateCommand request, CancellationToken cancellationToken)
        {
            var genre = new Domain.Models.Genre(request.Name);
            if (genre == null)
                throw new ApplicationException($"Error could not be found.");
            return await _genreRepository.AddAsync(genre);
        }
    }
}
