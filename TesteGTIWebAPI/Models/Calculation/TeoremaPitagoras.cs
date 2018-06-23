using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteGTIWebAPI.Models.Calculation
{
    public static class TeoremaPitagoras
    {
               

        public static double ObterDistancia(double latitudeXA, double longitudeYA, double latitudeXB, double longitudeYB)
        {

            double distancia;

            //Teorema de pitágoras: Distância = Raiz Quadrada de (latitudeXB -  latitudeXA)² + (longitudeYB - longitudeYA)²   
            try
            {
                distancia = Math.Sqrt((Math.Pow((latitudeXB - latitudeXA), 2) + Math.Pow((longitudeYB - longitudeYA), 2)));
                return Math.Round(distancia, 2);
            }
            catch (Exception ex)
            {
                
                throw new Exception(string.Format("Não foi possível calcular a distância. [{0}]", ex.Message));
            }
            

            
        }
    }
}