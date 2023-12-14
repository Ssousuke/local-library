using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class GenreDTO : BaseDTO
    {
        [JsonPropertyName("nome")]
        public string Name { get; private set; }
    }
}
