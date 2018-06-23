using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesteGTIClient.Model;

namespace TesteGTIClient.HTTPClient
{
    public class HTTPClient
    {
        private static string _baseAddress;
        private static string _baseRoute;
        private static string _mediaType;
        private static List<Amigo> _amigos;

        public HTTPClient()
        {
            _baseAddress = ConfigurationManager.AppSettings["baseAddress"];
            _baseRoute = ConfigurationManager.AppSettings["baseRoute"];
            _mediaType = ConfigurationManager.AppSettings["mediaType"];
            _amigos = new List<Amigo>();
        }

        public async Task AdicionaAmigo(Amigo amigo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response;
                    client.BaseAddress = new System.Uri(_baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    response = await client.PostAsJsonAsync(_baseRoute, amigo);
                    if (response.IsSuccessStatusCode)
                    {

                        Console.WriteLine("Amigo incluido com sucesso.");

                    }

                }

            }
            catch
            {
                
                throw;
            }
            

        }

        public ICollection<Amigo> BuscaAmigos(Amigo amigo)
        {
            try
            {
                BuscaAmigos(amigo.Latitude, amigo.Longitude).Wait();

                return _amigos;
            }
            catch
            {
                
                throw;
            }
            
        }


        private static async Task BuscaAmigos(double latitude, double longitude)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri(_baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    HttpResponseMessage response = await client.GetAsync(string.Format("{0}{1}/{2}", _baseRoute, latitude, longitude));
                    if (response.IsSuccessStatusCode)
                    {
                        _amigos = await response.Content.ReadAsAsync<List<Amigo>>();
                    }
                }
            }
            catch
            {
                
                throw;
            }
            
        }
    }
}
