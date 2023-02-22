using Newtonsoft.Json;
using BichinhoVirtual;
using BichinhoVirtual.Model;
using BichinhoVirtual.Services;
using RestSharp;
public class Program
{
    private static void Main(string[] args)
    {
        BichinhoVirtual();
    }

    private static void BichinhoVirtual()
    {
        Console.WriteLine("--- Bem vindo ao mundo do seu Bichinho Virtual ---\n");

        var response = PokemonService.ListarOpcoesEspecies();

            Console.WriteLine("--- Lista de espécies disponíveis: ---\n");
            Pokemons especies = response;
            int opcao = 1;
            foreach (Pokemon pokemon in especies.results)
            {
                Console.WriteLine(pokemon.name.ToUpper());
                opcao++;
            }

            Console.ReadKey();
        
    }
}