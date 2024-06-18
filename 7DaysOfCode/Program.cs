using _7DaysOfCode.Modelos;
using RestSharp;
using System.Text.Json;

static void ExibirPagina(int index, PokemonApiResponse pokemons)
{
    for (int i = (5 * index) - 5; i < 5 * index; i++)
    {
        Console.WriteLine($"{i+1} - {pokemons.Pokemons[i].Name}");
    }
}

string url = "https://pokeapi.co/api/v2/pokemon/";
var client = new RestClient(url);
var request = new RestRequest();
var response = await client.GetAsync(request);

var pokemons = JsonSerializer.Deserialize<PokemonApiResponse>(response?.Content!);


Console.Write("Olá! Qual seu nome? ");
string nome = Console.ReadLine()!;
Console.WriteLine($"Seja bem vindo {nome}");
Console.WriteLine("Por favor escolha uma das opções: ");
Console.WriteLine("[1] Adotar um Pokémon");
Console.WriteLine("[2] Listar os pokemons adotados");
Console.WriteLine("[3] Sair ");
string res = "4";
while (res != "0" && res != "1" && res != "2" && res != "3")
{
    Console.Write("Sua opção: ");
    res = Console.ReadLine()!;
}
int option = Convert.ToInt32(res);

switch (option)
{
    case 0:
        break;
    case 1:
        int pagina = 1;
        string resposta = "1";
        while (resposta != "0")
        {
            Console.Clear();

            Console.WriteLine($"Página {pagina}");
            Console.WriteLine($"Pokémons: ");
            Console.WriteLine();
            ExibirPagina(pagina, pokemons!);
            Console.WriteLine("[0] Sair");
            if (pagina > 1 && pagina < 4)
            {
                Console.WriteLine("[1] Voltar uma página");
                Console.WriteLine("[2] Próxima página");
            }
            else if (pagina == 4)
            {
                Console.WriteLine("[1] Voltar uma página");
            }
            else if (pagina == 1)
            {
                Console.WriteLine("[2] Próxima página");
            }
            resposta = Console.ReadLine()!;
            if (resposta == "1")
            {
                pagina--;
            }
            else if (resposta == "2")
            {
                pagina++;
            }
            if (pagina == 5) { pagina--; }
            if (pagina == 0) { pagina++; }
        }
        break;
    case 2:
        break;
    case 3:
        break;
}

foreach (var item in pokemons?.Pokemons!)
{
    client = new RestClient(item?.Url!);
    response = await client.GetAsync(request);
    var pokemonDetails = JsonSerializer.Deserialize<PokemonDetails>(response?.Content!);
    item!.Weight = pokemonDetails?.Weight;
    item.Height = pokemonDetails?.Height;
    item.Id = pokemonDetails?.Id;
}

Console.WriteLine("Lista dos Pokemons:");
Console.WriteLine();
foreach (var pokemon in pokemons.Pokemons)
{
    Console.WriteLine($"Nome: {pokemon.Name}");
    Console.WriteLine($"Peso: {pokemon.Weight}");
    Console.WriteLine($"Altura: {pokemon.Height}");
    Console.WriteLine($"Id: {pokemon.Id}");
    Console.WriteLine();
}

