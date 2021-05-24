using System;
//Modelo de que devuelve la api para la consulta de Climas
namespace InfoClimaWeb.Models
{
    public class ClimasModel
    {
        public int IdClima { get; set; }
        public int IdCiudades { get; set; }
        public string Ciudad { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public string Clima { get; set; }
        public string Termica { get; set; }
    }
}