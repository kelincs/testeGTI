using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteGTIWebAPI.Models;

namespace TesteGTIWebAPI.Tests
{
    [TestClass]
    public class AmigosTest
    {
        

        [TestMethod]        
        public void Post()
        {

            var amigos = CreatesObjectList();

            foreach (var amigo in amigos)
            {
                var amigoCompare = AmigoRepository.AdicionaAmigo(amigo);

                Assert.AreEqual<Amigo>(amigo, amigoCompare);
            }
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void PostWithTheSameCoordinates()
        {


            var amigo = CreatesObjectWithThesSameCoordinates();

            AmigoRepository.AdicionaAmigo(amigo);

            

        }

        [TestMethod]
        public void Get()
        {

            var amigo = CreatesObject();

            List<Amigo> amigos = (List<Amigo>)AmigoRepository.BuscarAmigos(amigo.Latitude, amigo.Longitude);
            Assert.IsTrue(amigos.Count <= 3);



        }

        private IEnumerable<Amigo> CreatesObjectList()
        {
            List<Amigo> retorno = new List<Amigo>();

            retorno.Add(new Amigo() { Nome = "Priscila", Latitude = 2, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Paulo", Latitude = 5, Longitude = 5 });
            retorno.Add(new Amigo() { Nome = "Kátia", Latitude = 1, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Leandro", Latitude = 3, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Valéria", Latitude = 4, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Heitor", Latitude = 10, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Lucas", Latitude = 2, Longitude = 10 });
            retorno.Add(new Amigo() { Nome = "Davi", Latitude = 20, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Dirceu", Latitude = 5, Longitude = 2 });
            retorno.Add(new Amigo() { Nome = "Pedro", Latitude = 4, Longitude = 1 });

            return retorno;
        }

        private Amigo CreatesObject()
        {
            var amigo = new Amigo()
            {
                Nome = "Gustavo",
                Latitude = 10,
                Longitude = 10
            };

            return amigo;
        }

        private Amigo CreatesObjectWithThesSameCoordinates()
        {
            var amigo = new Amigo()
            {
                Nome = "Carlos",
                Latitude = 2,
                Longitude = 2
            };

            return amigo;
        }
    }
}
