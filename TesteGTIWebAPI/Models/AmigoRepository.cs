using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TesteGTIWebAPI.Models.Calculation;


namespace TesteGTIWebAPI.Models
{
    public static class AmigoRepository
    {
        private static List<Amigo> amigos = new List<Amigo>();
        private static int numeroAmigos = 0;    

        

        public static Amigo AdicionaAmigo(Amigo amigo)
        {           

            if (amigo == null)
            {
                throw new ArgumentNullException("Amigo não pode ser nulo.");
            }
            if (amigos != null)
            {
                if (amigos.Find(f => f.Latitude == amigo.Latitude && f.Longitude == amigo.Longitude) != null)
                {
                    throw new ArgumentException("Já existe um amigo com a latitude e longitude informadas.");
                }

                amigos.Add(amigo);
            }

            return amigo;

            
        }

        public static IEnumerable<Amigo> BuscarAmigos(double latitude, double longitude)
        {
            try
            {

                Int32.TryParse(ConfigurationManager.AppSettings["numeroAmigos"], out numeroAmigos);

                foreach (var amigo in amigos)
                {
                    amigo.Distancia = TeoremaPitagoras.ObterDistancia(latitude, longitude, amigo.Latitude, amigo.Longitude);
                }

                if (amigos != null && amigos.Count >= numeroAmigos)
                {
                    amigos = amigos.OrderBy(f => f.Distancia).ToList().GetRange(0, numeroAmigos);
                }

                return amigos;
            }
            catch
            {                
                throw;
            }
            

        }

        

    }
}