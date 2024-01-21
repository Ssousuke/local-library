using LocalLibrary.Application.CQRS.Author.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Handler
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<Domain.Models.Author>>
    {
        private readonly IGenericRepository<Domain.Models.Author> _authorRepository;

        public GetAuthorsQueryHandler(IGenericRepository<Domain.Models.Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Domain.Models.Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAll();
        }
    }
}
