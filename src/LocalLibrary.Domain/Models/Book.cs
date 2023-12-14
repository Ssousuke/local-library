namespace LocalLibrary.Domain.Models
{
    public class Book : BaseModel
    {
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string ISBN { get; private set; }
        public Author Author { get; private set; }
        public Guid AuthorId { get; private set; }

        public Genre Genre { get; private set; }
        public Guid GenreId { get; private set; }

        public Language Language { get; private set; }
        public Guid LanguageId { get; private set; }
    }
}
