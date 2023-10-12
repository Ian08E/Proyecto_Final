using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMascota_v2.Modelo
{
    public class Animal
    {
        public int Id;
        public string Nombre;
        public bool Activo;

        public Animal()
        {

        }

        public Animal(string[] lineaAnimal)
        {
            this.Id = int.Parse(lineaAnimal[0]);
            this.Nombre = lineaAnimal[1];
            this.Activo = EsActivo(lineaAnimal[2]);
        }

        public static bool EsActivo(string esActivo)
        {
            if (esActivo.Equals("SI"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string EsActivo(bool esActivo)
        {
            if (esActivo)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }
        }
    }
}
