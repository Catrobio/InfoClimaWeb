
using System;
//Modelo de que devuelve la api para la consulta de ciudades
namespace InfoClimaWeb.Models
{
    public class CiudadesModel
    {        
        public int IdCiudades { get; set; }
        public int IdPaises { get; set; }
        public string Ciudad { get; set; }       
        public string Pais { get; set; }      
    }
}
