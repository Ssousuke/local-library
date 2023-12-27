using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class BookDTO : BaseDTO
    {
        [JsonPropertyName("titulo")]
        public string Title { get; set; }

        [JsonPropertyName("sumario")]
        public string Summary { get; set; }

        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }

        [JsonPropertyName("autor-id")]
        public Guid AuthorId { get; set; }

        [JsonPropertyName("genero-id")]
        public Guid GenreId { get; set; }

        [JsonPropertyName("linguagem-id")]
        public Guid LanguageId { get; set; }
    }
}
