using Newtonsoft.Json;
using BichinhoVirtual.Model;
using RestSharp;

namespace BichinhoVirtual.Services
{
    public class BichinhoVirtualService
    {
        public static Mascotes? ListarEspecies()
        {
            try
            {
                var response = ChamarAPI($"https://pokeapi.co/api/v2/pokemon/");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                { 
                    return JsonConvert.DeserializeObject<Mascotes>(response.Content);
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

        public static Mascote? BuscarCaracteristicasPorEspecie(string? especieMascote)
        {
            var response = ChamarAPI($"https://pokeapi.co/api/v2/pokemon/{especieMascote.ToLower()}");
            return JsonConvert.DeserializeObject<Mascote>(response.Content);
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
