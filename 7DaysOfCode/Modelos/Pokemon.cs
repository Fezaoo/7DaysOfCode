using System.Text.Json.Serialization;

namespace _7DaysOfCode.Modelos;

internal class Pokemon
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    public int? Id { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }

    public List<PokemonAbilitie>? Abilities { get; set; }
}
