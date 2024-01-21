using LocalLibrary.Application.CQRS.Genre.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Handler
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Domain.Models.Genre>
    {
        private readonly IGenericRepository<Domain.Models.Genre> _genreRepository;

        public GetGenreByIdQueryHandler(IGenericRepository<Domain.Models.Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Domain.Models.Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetByIdAsync(request.GenreId);
        }
    }
}
