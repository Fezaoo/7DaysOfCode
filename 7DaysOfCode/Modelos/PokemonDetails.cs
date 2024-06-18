using System.Text.Json.Serialization;

namespace _7DaysOfCode.Modelos;

internal class PokemonDetails
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
