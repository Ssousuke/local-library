using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Handler
{
    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, Domain.Models.Book>
    {
        private readonly IGenericRepository<Domain.Models.Book> _bookRepository;

        public BookCreateCommandHandler(IGenericRepository<Domain.Models.Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Domain.Models.Book> Handle(BookCreateCommand request, CancellationToken cancellationToken)
        {
            var book = new Domain.Models.Book(request.Title, request.ISBN, request.Summary, request.AuthorId, request.GenreId, request.LanguageId);
            if (book == null)
                throw new ApplicationException($"Error could not be found.");
            return await _bookRepository.AddAsync(book);
        }
    }
}
