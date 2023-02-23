using BichinhoVirtual.Model;
using BichinhoVirtual.Services;
using System.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        BichinhoVirtual();
    }

    private static void BichinhoVirtual()
    {
        string especieSelecionada = "";
        string opcaoUsuario;
        int jogar = 1;


        while (jogar == 1)
        {
            Console.Clear();
            Console.WriteLine("=== BEM VINDO AO MUNDO DO SEU BICHINHO VIRTUAL! ===\n");            
            Console.WriteLine("1 - ADOTAR UM MASCOTE VIRTUAL");
            Console.WriteLine("3 - SAIR");
            Console.WriteLine("\n=== DIGITE O NÚMERO DA OPÇÃO DESEJADA: ===");
            opcaoUsuario = Console.ReadLine();

            switch (opcaoUsuario)
            {
                case "1":
                    List<Pokemon> MascotesAdotados;
                    MascotesAdotados = new List<Pokemon>();
                    string opcaoUsuarioSubMenu = "1"; 
                    string especieMascote;

                    Console.Clear();
                    Console.WriteLine("=== Lista de espécies disponíveis: ===");

                    var response = PokemonService.ListarEspecies();
                    Pokemons especies = response;
                    //Listando espécies
                    foreach (Pokemon pokemon in especies.results)
                    {
                        Console.WriteLine(pokemon.name.ToUpper());
                    }

                    Console.WriteLine("\n=== Escreva o nome da espécie do seu interesse: ===");
                    especieMascote = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (especies.results.Any(l => l.name.ToUpper() == especieMascote))
                    {
                        while (opcaoUsuario != "3")
                        {
                            Console.Clear();
                            Console.WriteLine("=== ÓTIMA ESCOLHA! ===");
                            Console.WriteLine($"1 - SABER MAIS SOBRE O {especieMascote}");
                            Console.WriteLine($"2 - ADOTAR {especieMascote}");
                            Console.WriteLine($"3 - VOLTAR");
                            Console.WriteLine("\n=== DIGITE O NÚMERO DA OPÇÃO DESEJADA: ===");

                            opcaoUsuarioSubMenu = Console.ReadLine();                            

                            switch (opcaoUsuarioSubMenu)
                            {
                                case "1":
                                    Pokemon pokemon = new Pokemon();
                                    pokemon = PokemonService.BuscarCaracteristicasPorEspecie(especieMascote);
                                    Console.Clear();
                                    Console.WriteLine($"=== DETALHES DO POKEMON {especieMascote} ===");
                                    Console.WriteLine("Altura: " + pokemon.height);
                                    Console.WriteLine("Peso: " + pokemon.weight);
                                    Console.WriteLine("Habilidades: ");
                                    foreach (Abilities habilidade in pokemon.abilities)
                                    {
                                        Console.WriteLine(habilidade.ability.name.ToUpper() + " ");
                                    }
                                    Console.WriteLine("\n=== APERTE ENTER PARA VOLTAR AO MENU ANTERIOR ===");
                                    Console.ReadLine();
                                    break;

                                case "2":
                                    pokemon = PokemonService.BuscarCaracteristicasPorEspecie(especieMascote);
                                    MascotesAdotados.Add(pokemon);
                                    Console.Clear();
                                    Console.WriteLine("=== MASCOTE ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO! ===");
                                    Console.WriteLine();

                                    opcaoUsuario = "3";
                                    break;

                                case "3":
                                    opcaoUsuario = "3";
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida! Tente Novamente: ");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("=== Espécie informada não existe, favor digitar o nome de uma espécie da lista! ===");
                        Console.ReadKey();
                    }                    
                    break;
                case "3":
                    jogar = 0;
                    break;
                default:
                    Console.WriteLine("Opção Inválida! Tente Novamente. ");
                    break;
            }
        }
    }
}