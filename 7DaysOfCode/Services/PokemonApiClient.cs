using _7DaysOfCode.Modelos;
using RestSharp;
using System.Text.Json;

namespace _7DaysOfCode.Services;

internal class PokemonApiClient
{


    private readonly RestClient _client;
    private readonly RestRequest _request;

    public PokemonApiClient(RestClient Client)
    {
        _client = Client;
        _request = new RestRequest();
    }

    public async Task<PokemonApiResponse> GetPokemonsAsync()
    {
        var response = await _client.GetAsync(_request);
        var pokemons = JsonSerializer.Deserialize<PokemonApiResponse>(response?.Content!);

        return pokemons;
    }
    public async Task<PokemonDetails> ObterDetalhesAsync(Pokemon pokemon)
    {
        var client = CreateNewBaseUrl(pokemon.Url);
        var response = await client.GetAsync(_request);
        var details = JsonSerializer.Deserialize<PokemonDetails>(response.Content!);
        return details;
    }

    private RestClient CreateNewBaseUrl(string? url)
    {
        return new RestClient(url!);
    }
}
