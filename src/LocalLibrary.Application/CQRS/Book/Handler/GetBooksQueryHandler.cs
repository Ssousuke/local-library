using LocalLibrary.Application.CQRS.Book.Queries;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Handler
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Domain.Models.Book>>
    {
        private readonly IGenericRepository<Domain.Models.Book> _booksRepository;

        public GetBooksQueryHandler(IGenericRepository<Domain.Models.Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<Domain.Models.Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _booksRepository.GetAll();
        }
    }
}
