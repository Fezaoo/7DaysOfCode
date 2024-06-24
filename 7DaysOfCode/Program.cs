using _7DaysOfCode.Modelos;
using _7DaysOfCode.Services;
using RestSharp;
using System.Text.Json;




string url = "https://pokeapi.co/api/v2/pokemon/";

PokemonApiClient client = new PokemonApiClient(new RestClient(url));
var pokemons = client.GetPokemonsAsync().Result;


Console.Write("Olá! Qual seu nome? ");
string nome = Console.ReadLine()!;
void MenuPrincipal()
{
    List<Pokemon> pokemonsAdotados = new List<Pokemon>();

    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Seja bem vindo {nome}");
        Console.WriteLine("Por favor escolha uma das opções: ");
        Console.WriteLine("[0] Sair ");
        Console.WriteLine("[1] Adotar um Pokémon");
        Console.WriteLine("[2] Listar os pokemons adotados");
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
                string resposta = "p";
                while (resposta != "0")
                {
                    Console.Clear();

                    Console.WriteLine($"Página {pagina}");
                    Console.WriteLine($"Pokémons: ");
                    Console.WriteLine();
                    Exibir.ExibirPagina(pagina, pokemons!);
                    Console.WriteLine("[0] Sair");
                    if (pagina > 1 && pagina < 4)
                    {
                        Console.WriteLine("[v] Voltar uma página");
                        Console.WriteLine("[p] Próxima página");
                    }
                    else if (pagina == 4)
                    {
                        Console.WriteLine("[v] Voltar uma página");
                    }
                    else if (pagina == 1)
                    {
                        Console.WriteLine("[p] Próxima página");
                    }
                    resposta = Console.ReadLine()!;
                    resposta = resposta.ToLower();
                    if (resposta == "v")
                    {
                        if (pagina > 1) { pagina--; }
                    }
                    else if (resposta == "p")
                    {
                        if (pagina < 4) { pagina++; }
                    }
                    else if (resposta == "0") { break; }
                    else if (Convert.ToInt32(resposta) <= pokemons.Pokemons.Count() && Convert.ToInt32(resposta) >= 0)
                    {
                        int respostaNumerica = Convert.ToInt32(resposta) - 1;

                        var detalhes = client.ObterDetalhesAsync(pokemons.Pokemons[respostaNumerica]).Result;
                        pokemons.Pokemons[respostaNumerica].Id = detalhes.Id;
                        pokemons.Pokemons[respostaNumerica].Height = detalhes.Height;
                        pokemons.Pokemons[respostaNumerica].Weight = detalhes.Weight;
                        pokemons.Pokemons[respostaNumerica].Abilities = detalhes.pokemonAbilities;
                        Exibir.ExibirDetalhesDeUmPokemon(pokemons.Pokemons[respostaNumerica]);
                        Console.WriteLine();
                        string adotar = "";
                        while (adotar != "y" && adotar != "n")
                        {
                            Console.Write($"Deseja adotar este pokemon? [y/n]: ");
                            adotar = Console.ReadLine()!.ToLower();
                        }
                        if (adotar == "y")
                        {
                            Console.WriteLine($"Você adotou o pokemon: {pokemons.Pokemons[respostaNumerica].Name} ");
                            pokemonsAdotados.Add(pokemons.Pokemons[respostaNumerica]);
                            pokemons.Pokemons.RemoveAt(respostaNumerica);
                        }
                        Thread.Sleep(1000);
                    }
                }
                break;
            case 2:
                bool opcaoMenuPokemonAdotado = true;
                while (opcaoMenuPokemonAdotado)
                {
                Console.Clear();
                Console.WriteLine("Selecione um pokemon: ");
                Exibir.ExibirPokemonsAdotados(pokemonsAdotados);
                Console.Write("Opção: ");
                int opcaoPokemonAdotado = Convert.ToInt32(Console.ReadLine());
                    opcaoPokemonAdotado--;
                if (pokemonsAdotados.ElementAtOrDefault(opcaoPokemonAdotado) != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Selecione uma opção: ");
                        Console.WriteLine("[1] Alimentar pokemon");
                        Console.WriteLine("[2] Por pokemon para dormir");
                        Console.WriteLine("[3] Brincar com pokemon ");
                        Console.Write("Sua opção: ");
                        int opcaoInteracao = Convert.ToInt32(Console.ReadLine());
                        if (opcaoInteracao == 1) { pokemonsAdotados[opcaoPokemonAdotado].AlimentarPokemon(); }
                        if (opcaoInteracao == 2) { pokemonsAdotados[opcaoPokemonAdotado].DormirPokemon(); }
                        if (opcaoInteracao == 3) { pokemonsAdotados[opcaoPokemonAdotado].BrincarPokemon(); }
                    }
                    string respostaInteracao = "";
                    while (respostaInteracao != "y" && respostaInteracao != "n")
                    {
                        Console.Write("Sair? [y/n]: ");
                        respostaInteracao = Console.ReadLine()!;
                    }
                    if (respostaInteracao == "y") break;
                }

                Thread.Sleep(400);
                break;
            case 3:
                break;
        }
        if (option == 0) { break; }
    }
}



MenuPrincipal();

//foreach (var item in pokemons?.Pokemons!)
//{
//    client = new RestClient(item?.Url!);
//    response = await client.GetAsync(request);
//    var pokemonDetails = JsonSerializer.Deserialize<PokemonDetails>(response?.Content!);
//    item!.Weight = pokemonDetails?.Weight;
//    item.Height = pokemonDetails?.Height;
//    item.Id = pokemonDetails?.Id;
//    item.Abilities = pokemonDetails?.pokemonAbilities;
//}

//Console.WriteLine("Lista dos Pokemons:");
//Console.WriteLine();
//foreach (var pokemon in pokemons.Pokemons)
//{
//    Console.WriteLine($"Nome: {pokemon.Name}");
//    Console.WriteLine($"Peso: {pokemon.Weight}");
//    Console.WriteLine($"Altura: {pokemon.Height}");
//    Console.WriteLine($"Id: {pokemon.Id}");
//    Console.WriteLine("Abilities: ");
//    foreach (var abilitie in pokemon.Abilities)
//    {
//        Console.WriteLine(abilitie.Abilitie.AbilitieName.ToUpper());

//    }
//    Console.WriteLine();
//}