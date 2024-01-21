namespace LocalLibrary.Application.CQRS.Author.Commands
{
    public class AuthorUpdateCommand : AuthorCommand
    {
        public Guid AuthorId { get; set; }
    }
}
