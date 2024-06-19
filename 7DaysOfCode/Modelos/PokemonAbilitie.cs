using System.Text.Json.Serialization;

namespace _7DaysOfCode.Modelos;

internal class PokemonAbilitie
{
    [JsonPropertyName("ability")]
    public Abilitie? Abilitie { get; set; }
}
