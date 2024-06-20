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

    public void AlimentarPokemon()
    {
        Console.WriteLine($"Você alimentou o {Name}! ");
    }
    
    public void DormirPokemon()
    {
        Console.WriteLine($"Você colocou o {Name} para dormir! ");

    }

    public void BrincarPokemon()
    {
        Console.WriteLine($"Você brincou com o {Name}! ");
    }
}
