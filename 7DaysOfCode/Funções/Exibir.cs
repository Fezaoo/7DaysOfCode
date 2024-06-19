
using _7DaysOfCode.Modelos;

namespace _7DaysOfCode.Modelos
{
    internal class Exibir
    {
        public static void ExibirDetalhesDeUmPokemon(Pokemon pokemon)
        {
            Console.WriteLine($"Nome: {pokemon.Name}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Id: {pokemon.Id}");
            Console.WriteLine("Abilities: ");
            foreach (var abilitie in pokemon.Abilities)
            {
                Console.WriteLine(abilitie.Abilitie.AbilitieName.ToUpper());

            }
        }
        public static void ExibirPagina(int index, PokemonApiResponse pokemons)
        {
            for (int i = (5 * index) - 5; i < 5 * index && i < pokemons.Pokemons!.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {pokemons.Pokemons[i].Name}");
            }
        }

        public static void ExibirPokemonsAdotados(List<Pokemon> pokemonsAdotados)
        {
            Console.WriteLine($"Quantidade: {pokemonsAdotados.Count}");
            Console.WriteLine("Seus pokemons adotados: ");
            foreach (var pokemon in pokemonsAdotados)
            {
                Console.WriteLine(pokemon.Name);
            }
            Console.Write("Aperte qualquer tecla para voltar ");
        }
    }
}
