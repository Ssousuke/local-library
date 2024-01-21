using LocalLibrary.Application.CQRS.Book.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Handler
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Domain.Models.Book>
    {
        private readonly IGenericRepository<Domain.Models.Book> _booksRepository;

        public GetBookByIdQueryHandler(IGenericRepository<Domain.Models.Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Domain.Models.Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _booksRepository.GetByIdAsync(request.BookId);
        }
    }
}
