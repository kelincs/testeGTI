using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteGTIWebAPI.Models
{
    public class Amigo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Nome { get; set; }
        public double Distancia { get; set; }
    }
}