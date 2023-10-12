using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaMascota_v2.Modelo;
using TiendaMascota_v2.Repositorio;

namespace TiendaMascota_v2.Controlador
{
    public class AnimalControlador
    {
        public static void IniciarRepositorio()
        {
            AnimalRepositorio.IniciarRepositorio();
        }

        public static void AgregarAnimal(Animal animal)
        {
            // Validaciones: ValidarAnimal();

            AnimalRepositorio.AgregarAnimal(animal);
        }

        public static void ActualizarAnimal(int id, Animal animal)
        {
            AnimalRepositorio.ActualizarAnimal(id, animal);
        }

        public static void EliminarAnimal(int id)
        {
            AnimalRepositorio.EliminarAnimal(id);
        }

        public static List<Animal> ObtenerAnimales()
        {
            return AnimalRepositorio.ObtenerAnimales();
        }
        public static int ObtenerUltimoId()
        {
            return AnimalRepositorio.UltimoId;
        }

        public static Animal ObtenerAnimalPorId(int id)
        {
            return AnimalRepositorio.ObtenerAnimalPorId(id);
        }

        public static Animal ObtenerAnimalPorNombre(string nombre)
        {
            return AnimalRepositorio.ObtenerAnimalPorNombre(nombre);
        }

        public static bool HuboModificaciones(Animal animalModificado)
        {
            bool huboModificaciones = false;

            Animal animalBase = ObtenerAnimalPorId(animalModificado.Id);

            if(!animalModificado.Nombre.Equals(animalBase.Nombre) || 
                !animalModificado.Activo.Equals(animalBase.Activo))
            {
                huboModificaciones = true;
            }

            return huboModificaciones;
        }
    }
}
