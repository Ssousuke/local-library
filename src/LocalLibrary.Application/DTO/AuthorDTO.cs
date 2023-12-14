using LocalLibrary.Domain.Models;
using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class AuthorDTO : BaseDTO
    {
        [JsonPropertyName("nome")]
        public string Name { get; private set; }

        [JsonPropertyName("data-nascimento")]
        public DateTime DateOfBirth { get; private set; }

        [JsonPropertyName("data-morte")]
        public DateTime? DateOfDeath { get; private set; }

        [JsonIgnore]
        public IEnumerable<Book> Books { get; private set; }
    }
}
