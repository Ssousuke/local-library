using LocalLibrary.Domain.Models;
using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class BookDTO : BaseDTO
    {
        [JsonPropertyName("titulo")]
        public string Title { get; private set; }

        [JsonPropertyName("sumario")]
        public string Summary { get; private set; }

        [JsonPropertyName("isbn")]
        public string ISBN { get; private set; }

        [JsonPropertyName("autor")]
        public Author Author { get; private set; }

        [JsonPropertyName("autor-id")]
        public Guid AuthorId { get; private set; }

        [JsonPropertyName("genero")]
        public Genre Genre { get; private set; }

        [JsonPropertyName("genero-id")]
        public Guid GenreId { get; private set; }

        [JsonPropertyName("linguagem")]
        public Language Language { get; private set; }

        [JsonPropertyName("linguagem-id")]
        public Guid LanguageId { get; private set; }
    }
}
