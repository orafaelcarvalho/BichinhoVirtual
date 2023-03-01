using AutoMapper;
using BichinhoVirtual.Model;
using BichinhoVirtual.Services;
using BichinhoVirtual.View;

namespace BichinhoVirtual.Controller
{
    public class BichinhoVirtualController
    {
        private string NomeDoJogador { get; set; }
        private List<Mascote> MascotesAdotados { get; set; }
        private BichinhoVirtualView Mensagens { get; set; }
        private MascoteMapping Mapeador;

        public BichinhoVirtualController()
        {
            MascotesAdotados = new List<Mascote>();
            Mensagens = new BichinhoVirtualView();            
            Mapeador = new MascoteMapping();
        }

        public void JogoBichinhoVirtual()
        {

            string opcaoUsuario;
            int jogar = 1;

            while (jogar == 1)
            {
                Mensagens.MenuInicial();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        MenuAdocao(opcaoUsuario);
                        break;
                    case "2":
                        MenuInteracao();
                        //Console.ReadKey();
                        break;
                    case "3":
                        jogar = 0;
                        break;
                    default:
                        Mensagens.OpcaoInvalida("opcao");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void MenuAdocao(string opcaoUsuario)
        {
            string opcaoUsuarioSubMenu = "1";

            Pokemons especies = PokemonService.ListarEspecies();
            Mensagens.MenuAdocao(especies);
            Mapeador = new MascoteMapping();

            string especieMascote = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (especies.results.Any(l => l.name.ToUpper() == especieMascote))
            {
                while (opcaoUsuario != "3")
                {
                    Mensagens.MenuMascote(especieMascote);

                    opcaoUsuarioSubMenu = Console.ReadLine();

                    Pokemon pokemon = new();
                    Mascote mascote = new();

                    switch (opcaoUsuarioSubMenu)
                    {
                        case "1":
                            pokemon = PokemonService.BuscarCaracteristicasPorEspecie(especieMascote);
                                                        
                            mascote = Mapper.Map<Pokemon, Mascote>(pokemon);

                            Mensagens.ExibirDetalhesMascote(mascote);

                            Console.ReadLine();
                            break;
                        case "2":
                            pokemon = PokemonService.BuscarCaracteristicasPorEspecie(especieMascote);
                            
                            mascote = Mapper.Map<Pokemon, Mascote>(pokemon);

                            MascotesAdotados.Add(mascote);
                            Mensagens.ExibirMensagemAdocaoConcluida();
                            opcaoUsuario = "3";
                            Console.ReadLine();
                            break;

                        case "3":
                            opcaoUsuario = "3";
                            break;
                        default:
                            Mensagens.OpcaoInvalida("opcao");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                Mensagens.OpcaoInvalida("especie");
                Console.ReadKey();
            }
        }

        private void MenuInteracao()
        {
            string opcaoUsuario = "0";
            int indiceMascote;

            indiceMascote = Mensagens.MenuConsultarMascotes(MascotesAdotados);
            while (opcaoUsuario != "4")
            {
                opcaoUsuario = Mensagens.InteragirComMascotes(MascotesAdotados[indiceMascote]);

                switch (opcaoUsuario)
                {
                    case "1":
                        Mensagens.DetalhesMascoteAdotado(MascotesAdotados[indiceMascote]);
                        break;
                    case "2":
                        MascotesAdotados[indiceMascote].AlimentarMascote();
                        Mensagens.AlimentarMascote();

                        if (!MascotesAdotados[indiceMascote].SaudeMascote())
                            Mensagens.GameOver(MascotesAdotados[indiceMascote]);

                        break;
                    case "3":
                        MascotesAdotados[indiceMascote].BrincarMascote();
                        Mensagens.BrincarMascote();
                        if (!MascotesAdotados[indiceMascote].SaudeMascote())
                        {
                            Mensagens.GameOver(MascotesAdotados[indiceMascote]);
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }
        }
    }
}
