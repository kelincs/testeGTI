using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteGTIWebAPI.Models;


namespace TesteGTIWebAPI.Controllers
{
    public class AmigosController : ApiController
    {

       
        
        [HttpGet]
        public IEnumerable<Amigo> Get(double latitude, double longitude)
        {
          IEnumerable<Amigo> amigos = AmigoRepository.BuscarAmigos(latitude, longitude);
            if (amigos == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return amigos;
        }

        [HttpPost]
        public void Post(Amigo amigo)
        {
            try
            {
                AmigoRepository.AdicionaAmigo(amigo);           
            }
            catch
            {
                throw;
            }
            
        }
    }
}
