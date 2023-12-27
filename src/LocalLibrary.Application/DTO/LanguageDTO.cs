using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public class LanguageDTO : BaseDTO
    {
        [JsonPropertyName("linguagem")]
        public string Name { get; set; }
    }
}
