using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Handler
{
    public class BookRemoveCommandHandler : IRequestHandler<BookRemoveCommand, bool>
    {
        private readonly IGenericRepository<Domain.Models.Book> _bookRepository;

        public BookRemoveCommandHandler(IGenericRepository<Domain.Models.Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(BookRemoveCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book == null)
                throw new ApplicationException($"Error could not be found.");
            return await _bookRepository.DeleteByIdAsync(book.Id);
        }
    }
}

