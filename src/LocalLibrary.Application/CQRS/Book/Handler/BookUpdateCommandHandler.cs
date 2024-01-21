using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Handler
{
    public class BookUpdateCommandHandler : IRequestHandler<BookUpdateCommand, Domain.Models.Book>
    {
        private readonly IGenericRepository<Domain.Models.Book> _bookRepository;

        public BookUpdateCommandHandler(IGenericRepository<Domain.Models.Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Domain.Models.Book> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
        {
            var book = new Domain.Models.Book(request.BookId, request.Title, request.Summary, request.ISBN, request.AuthorId, request.GenreId, request.LanguageId);

            if (book is null)
                throw new ApplicationException($"Error could not be found.");
            return await _bookRepository.UpdateAsync(book);
        }
    }
}
