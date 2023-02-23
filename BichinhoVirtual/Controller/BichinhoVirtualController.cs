using BichinhoVirtual.Model;
using BichinhoVirtual.Services;
using BichinhoVirtual.View;

namespace BichinhoVirtual.Controller
{
    public class BichinhoVirtualController
    {
        public void JogoBichinhoVirtual()
        {
            BichinhoVirtualView Mensagens = new BichinhoVirtualView();
            List<Mascote> mascotesAdotados = new List<Mascote>();

            string opcaoUsuario;
            int jogar = 1;

            while (jogar == 1)
            {
                Mensagens.MenuInicial();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        string opcaoUsuarioSubMenu = "1";
                                                
                        Mascotes especies = BichinhoVirtualService.ListarEspecies();
                        Mensagens.MenuAdocao(especies);
                        
                        string especieMascote = Console.ReadLine().ToUpper();
                        Console.WriteLine();                        

                        if (especies.results.Any(l => l.name.ToUpper() == especieMascote))
                        {
                            while (opcaoUsuario != "3")
                            {
                                Mensagens.MenuMascote(especieMascote);

                                opcaoUsuarioSubMenu = Console.ReadLine();

                                Mascote mascote = new Mascote();

                                switch (opcaoUsuarioSubMenu)
                                {
                                    case "1":
                                        mascote = BichinhoVirtualService.BuscarCaracteristicasPorEspecie(especieMascote);
                                        Mensagens.ExibirDetalhesMascote(mascote);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        mascote = BichinhoVirtualService.BuscarCaracteristicasPorEspecie(especieMascote);
                                        mascotesAdotados.Add(mascote);
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
                        break;
                    case "2":
                        Mensagens.ExibirMascotesAdotados(mascotesAdotados);
                        Console.ReadKey();
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
    }
}
