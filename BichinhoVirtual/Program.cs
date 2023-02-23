using BichinhoVirtual.Controller;
using BichinhoVirtual.View;

public class Program
{
    private static void Main(string[] args)
    {
        BichinhoVirtualView mensagens = new BichinhoVirtualView();
        mensagens.BoasVindas();

        BichinhoVirtualController controller = new BichinhoVirtualController();
        controller.JogoBichinhoVirtual();
    }
}