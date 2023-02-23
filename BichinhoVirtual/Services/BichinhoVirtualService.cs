using Newtonsoft.Json;
using BichinhoVirtual.Model;
using RestSharp;

namespace BichinhoVirtual.Services
{
    public class BichinhoVirtualService
    {
        public static Pokemons? ListarEspecies()
        {
            try
            {
                var response = ChamarAPI($"https://pokeapi.co/api/v2/pokemon/");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                { 
                    return JsonConvert.DeserializeObject<Pokemons>(response.Content);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Pokemon? BuscarCaracteristicasPorEspecie(string? especieMascote)
        {
            var response = ChamarAPI($"https://pokeapi.co/api/v2/pokemon/{especieMascote.ToLower()}");
            return JsonConvert.DeserializeObject<Pokemon>(response.Content);
        }
        public static RestResponse ChamarAPI(string url)
        {
            var client = new RestClient(url);
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            return response;
        }
    }
}
