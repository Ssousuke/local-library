using LocalLibrary.Application.CQRS.Author.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Handler
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Domain.Models.Author>
    {
        private readonly IGenericRepository<Domain.Models.Author> _authorRepository;

        public GetAuthorByIdQueryHandler(IGenericRepository<Domain.Models.Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Domain.Models.Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetByIdAsync(request.AuthorId);
        }
    }
}
