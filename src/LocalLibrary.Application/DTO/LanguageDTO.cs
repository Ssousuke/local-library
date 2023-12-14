using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class LanguageDTO
    {
        [JsonPropertyName("linguagem")]
        public string Name { get; set; }
    }
}
