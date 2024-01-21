using MediatR;

namespace LocalLibrary.Application.CQRS.Book.Commands
{
    public class BookRemoveCommand : IRequest<bool>
    {
        public BookRemoveCommand(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; set; }

    }
}
