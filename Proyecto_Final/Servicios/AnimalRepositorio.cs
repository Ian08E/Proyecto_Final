using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMascota_v2.Modelo;

namespace TiendaMascota_v2.Repositorio
{
    public class AnimalRepositorio
    {
        public static List<Animal> ListaAnimales { get; set; }
        public static int UltimoId 
        {
            get 
            {
                return ObtenerUltimoId();
            }
            set
            {
                UltimoId = value;
            }
        }

        public static void IniciarRepositorio()
        {
            ListaAnimales = new List<Animal>();

            if(!File.Exists("Animales.txt"))
            {
                StreamWriter archivoNuevo = new StreamWriter("Animales.txt");
                archivoNuevo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("Animales.txt");

                while(!archivo.EndOfStream)
                {
                    string datosAnimal = archivo.ReadLine();

                    string[] datosDivididos = datosAnimal.Split(';');

                    Animal animal = new Animal(datosDivididos);

                    ListaAnimales.Add(animal);
                }

                archivo.Close();
            }
            
        }

        public static void AgregarAnimal(Animal animal)
        {
            ListaAnimales.Add(animal);
            GuardarEnMemoria(animal);
        }

        public static void ActualizarAnimal(int id, Animal animal)
        {
            int indice = ListaAnimales.FindIndex(a => a.Id == id);

            if(indice != -1)
            {
                ListaAnimales[indice] = animal;
            }

            GuardarEnMemoriaLista();
        }

        public static void EliminarAnimal(int id)
        {
            Animal animal = ListaAnimales.FirstOrDefault(a => a.Id == id);
            animal.Activo = false;

            ActualizarAnimal(animal.Id, animal);
        }

        public static void GuardarEnMemoria(Animal animal)
        {
            StreamWriter archivo = new StreamWriter("Animales.txt", true);
            archivo.WriteLine(animal.Id + ";" + animal.Nombre + ";" + Animal.EsActivo(animal.Activo));
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("Animales.txt");
            foreach(Animal animal in ListaAnimales)
            {
                archivo.WriteLine(animal.Id + ";" + animal.Nombre + ";" + Animal.EsActivo(animal.Activo));
            }
            archivo.Close();
        }

        public static List<Animal> ObtenerAnimales()
        {
            return ListaAnimales;
        }

        private static int ObtenerUltimoId()
        {
            int ultimoId = 0;

            if(ListaAnimales.Count > 0)
            {
                ultimoId = ListaAnimales[ListaAnimales.Count - 1].Id;

                ultimoId = ultimoId + 1;

                return ultimoId;
            }
            else
            {
                return 1;
            }
        }

        public static Animal ObtenerAnimalPorId(int id)
        {
            Animal animal = ListaAnimales.FirstOrDefault(a => a.Id == id);

            return animal;
        }

        public static Animal ObtenerAnimalPorNombre(string nombre)
        {
            Animal animal = ListaAnimales.FirstOrDefault(a => a.Nombre == nombre);

            return animal;
        }
    }
}
