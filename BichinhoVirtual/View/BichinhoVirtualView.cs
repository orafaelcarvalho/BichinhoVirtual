using BichinhoVirtual.Model;

namespace BichinhoVirtual.View
{
    public class BichinhoVirtualView
    {
        string nomeDoJogador = "";
        public void BoasVindas()
        {
            Console.WriteLine(@"
########   #   ########   #      #   #   ##     #   #      #   ########   VIRTUAL            #
#      #   #   #          #      #   #   # #    #   #      #   #      #   VIRTUAL          #  #
#      #   #   #          #      #   #   # #    #   #      #   #      #   VIRTUAL    # # # # # # # # ##
#    ###   #   #          #      #   #   #  #   #   #      #   #      #   VIRTUAL       # #     #  #
#####      #   #          ########   #   #  #   #   ########   #      #   VIRTUAL        #      ##
#    ###   #   #          #      #   #   #   #  #   #      #   #      #   VIRTUAL       #  #  #   #
#      #   #   #          #      #   #   #   #  #   #      #   #      #   VIRTUAL      #    ##     #
#      #   #   #          #      #   #   #    # #   #      #   #      #   VIRTUAL     #   #    #    #
########   #   ########   #      #   #   #      #   #      #   ########   VIRTUAL    #  #         #  #

");
            Console.WriteLine("--- QUAL O SEU NOME?");
            nomeDoJogador = Console.ReadLine().ToUpper();
        }
        public void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("\n--- BEM VINDO AO MUNDO DO SEU BICHINHO VIRTUAL!\n");
            Console.WriteLine($"{nomeDoJogador} VOCÊ DESEJA:");
            Console.WriteLine("1 - ADOTAR UM MASCOTE VIRTUAL");
            Console.WriteLine("2 - VER SEUS MASCOTES");
            Console.WriteLine("3 - SAIR");
            Console.WriteLine("\n--- DIGITE O NÚMERO DA OPÇÃO DESEJADA:");
        }

        public void MenuAdocao(Mascotes especies)
        {
            Console.Clear();
            Console.WriteLine($"\n--- {nomeDoJogador}, ADOTE UM BICHINHO VIRTUAL!\n");
            Console.WriteLine("--- LISTA DE ESPÉCIES DISPONÍVEIS: ---");
            //Listando espécies
            foreach (Mascote mascote in especies.results)
            {
                Console.WriteLine(mascote.name.ToUpper());
            }

            Console.WriteLine("\n--- ESCREVA O NOME DA ESPÉCIE DO SEU INTERESSE:");
        }

        public void MenuMascote(string especieMascote)
        {
            Console.Clear();
            Console.WriteLine("\n--- ÓTIMA ESCOLHA!");
            Console.WriteLine($"1 - SABER MAIS SOBRE O {especieMascote}");
            Console.WriteLine($"2 - ADOTAR {especieMascote}");
            Console.WriteLine($"3 - VOLTAR");
            Console.WriteLine("\n--- DIGITE O NÚMERO DA OPÇÃO DESEJADA:");
        }

        public void ExibirDetalhesMascote(Mascote mascote)
        {
            Console.Clear();
            Console.WriteLine($"\n--- DETALHES DO MASCOTE {mascote.name.ToUpper()}");
            Console.WriteLine("Altura: " + mascote.height);
            Console.WriteLine("Peso: " + mascote.weight);
            Console.Write("Habilidades: ");
            string habilidades = "";
            foreach (Abilities habilidade in mascote.abilities)
            {
                habilidades = habilidades + habilidade.ability.name.ToUpper() + ", ";
            }
            habilidades = habilidades.Remove(habilidades.Length - 2);
            Console.WriteLine(habilidades);

            Console.WriteLine("\n--- APERTE ENTER PARA VOLTAR AO MENU ANTERIOR");
        }

        public void ExibirMensagemAdocaoConcluida()
        {
            Console.Clear();
            Console.WriteLine("\n--- MASCOTE ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO!");
            Console.WriteLine(@"
                           *****
                         *********
                        ***********
                       *************
                       *************
                        ***********
                         *********
                           *****
");
            Console.WriteLine("\n--- APERTE ENTER PARA VOLTAR AO MENU ANTERIOR");
        }

        public void OpcaoInvalida(string opcao)
        {
            if (opcao == "opcao")
            {
                Console.WriteLine("--- OPÇÃO INVÁLIDA! TENTE NOVAMENTE");
            }
            else if (opcao == "especie")
            {
                Console.WriteLine("--- ESPÉCIE INFORMADA NÃO EXISTE, FAVOR DIGITAR O NOME DE UMA ESPÉCIE DA LISTA!");
            }
        }

        internal void ExibirMascotesAdotados(List<Mascote> mascotesAdotados)
        {
            Console.Clear();
            Console.WriteLine($"\n--- MASCOTES ADOTADOS - VOCÊ POSSUI {mascotesAdotados.Count} MASCOTE(S)");
            foreach (var item in mascotesAdotados)
            {
                Console.WriteLine($"\n--- DETALHES DO MASCOTE {item.name.ToUpper()}");
                Console.WriteLine("Altura: " + item.height);
                Console.WriteLine("Peso: " + item.weight);
                Console.Write("Habilidades: ");
                string habilidades = "";
                foreach (Abilities habilidade in item.abilities)
                {
                    habilidades = habilidades + habilidade.ability.name.ToUpper() + ", ";
                }
                habilidades = habilidades.Remove(habilidades.Length - 2);
                Console.WriteLine(habilidades);
            }
            Console.WriteLine("\n--- APERTE ENTER PARA VOLTAR AO MENU ANTERIOR");
        }
    }

}
