using _7DaysOfCode.Modelos;
using System.Text.Json;
var options = new JsonSerializerOptions
{
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true
};

using (HttpClient client = new HttpClient())
{
    string url = "https://pokeapi.co/api/v2/pokemon/";
    var response = await client.GetStringAsync(url);
    var pokemons = JsonSerializer.Deserialize<PokemonApiResponse>(response);

    foreach (var pokemon in pokemons.Pokemons)
    {
        string detailsUrl= pokemon.url;
        var detailsResponse = await client.GetStringAsync(detailsUrl);
        var details = JsonSerializer.Deserialize<PokemonDetails>(detailsResponse);
        pokemon.Weight = details.Weight;
        pokemon.Height = details.Height;
        pokemon.Id = details.Id;
    }
    Console.WriteLine("Lista dos Pokemons:");
    Console.WriteLine();
    foreach (var pokemon in pokemons.Pokemons)
    {
        Console.WriteLine($"Nome: {pokemon.Name}");
        Console.WriteLine($"Peso: {pokemon.Weight}");
        Console.WriteLine($"Altura: {pokemon.Height}");
        Console.WriteLine($"ID: {pokemon.Id}");
        Console.WriteLine();
    }
}




