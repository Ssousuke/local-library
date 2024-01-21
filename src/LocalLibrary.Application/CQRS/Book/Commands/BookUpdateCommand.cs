namespace LocalLibrary.Application.CQRS.Book.Commands
{
    public class BookUpdateCommand : BookCommand
    {
        public Guid BookId { get; set; }
    }
}
