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

        [JsonPropertyName("autor")]
        public AuthorDTO Author { get; set; }

        [JsonPropertyName("genero")]
        public GenreDTO Genre { get; set; }

        [JsonPropertyName("linguagem")]
        public LanguageDTO Language { get; set; }
    }
}
