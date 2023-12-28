using System.Text.Json.Serialization;

namespace LocalLibrary.Application.DTO
{
    public abstract class BaseDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("criado-em")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("atualizado-em")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
