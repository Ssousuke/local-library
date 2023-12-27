using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class AuthorDTO : BaseDTO
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonPropertyName("data-nascimento")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("data-morte")]
        public DateTime? DateOfDeath { get; set; }

    }
}
