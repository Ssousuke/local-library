using LocalLibrary.Application.CQRS.Genre.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Genre.Handler
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IEnumerable<Domain.Models.Genre>>
    {
        private readonly IGenericRepository<Domain.Models.Genre> _genreRepository;

        public GetGenresQueryHandler(IGenericRepository<Domain.Models.Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Domain.Models.Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetAll();
        }
    }
}
