namespace LocalLibrary.Application.CQRS.Genre.Commands
{
    public class GenreUpdateCommand : GenreCommand
    {
        public Guid GenreId { get; set; }
    }
}
