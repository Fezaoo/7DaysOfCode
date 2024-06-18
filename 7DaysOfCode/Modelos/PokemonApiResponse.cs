using System.Text.Json.Serialization;

namespace _7DaysOfCode.Modelos;

internal class PokemonApiResponse
{
    [JsonPropertyName("results")]
    public List<Pokemon>? Pokemons { get; set; }
}
