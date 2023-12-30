using LocalLibrary.Domain.ValidationDomainException;

namespace LocalLibrary.Domain.Models
{
    public sealed class Book : BaseModel
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

        private void ValidateDomain(string title, string summary, string iSBN, Guid authorId, Guid genreId, Guid languageId)
        {

            // Validate properties not null
            DomainException.When(string.IsNullOrEmpty(title), "title cannot be null");
            DomainException.When(string.IsNullOrEmpty(summary), "summary cannot be null");
            DomainException.When(string.IsNullOrEmpty(iSBN), "ISBN cannot be null");

            // Validate id's
            DomainException.When(string.IsNullOrEmpty(authorId.ToString()), "author is required");
            DomainException.When(string.IsNullOrEmpty(genreId.ToString()), "genre is required");
            DomainException.When(string.IsNullOrEmpty(languageId.ToString()), "language is required");

            iSBN = ValidateFields.CheckAndRemoveSpecialCharacters(iSBN);

            // Validate length properties
            DomainException.When(title.Length > 150, "max length is 150");
            DomainException.When(summary.Length > 255, "max length is 255");
            DomainException.When(iSBN.Length > 13, "max length is 13");

            Title = title;
            Summary = summary;
            ISBN = iSBN;
            AuthorId = authorId;
            GenreId = genreId;
            LanguageId = languageId;
        }

        public Book(string title, string summary, string iSBN, Guid authorId, Guid genreId, Guid languageId)
        {
            ValidateDomain(title, summary, iSBN, authorId, genreId, languageId);
        }

        public void UpdateTitle(string newTitle)
        {
            DomainException.When(string.IsNullOrEmpty(newTitle), "title cannot be null");
            DomainException.When(newTitle.Length > 150, "max length is 150");

            Title = newTitle;
        }
    }
}
