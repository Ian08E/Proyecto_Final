using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMascota_v2.Controlador;
using TiendaMascota_v2.Modelo;

namespace TiendaMascota_v2.Repositorio
{
    public class UsuarioRepositorio
    {
        public static List<Usuario> ListaUsuarios { get; set; }
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
            ListaUsuarios = new List<Usuario>();

            if(!File.Exists("Usuarios.txt"))
            {
                StreamWriter archivoNuevo = new StreamWriter("Usuarios.txt");
                archivoNuevo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("Usuarios.txt");

                while(!archivo.EndOfStream)
                {
                    string datosUsuarios = archivo.ReadLine();

                    if(!datosUsuarios.Equals(""))
                    {
                        string[] datosDivididos = datosUsuarios.Split(';');

                        Usuario usuario = new Usuario(datosDivididos);

                        ListaUsuarios.Add(usuario);
                    }
                }

                archivo.Close();
            }
            
        }

        public static void AgregarUsuarios(Usuario usuario)
        {
            ListaUsuarios.Add(usuario);
            GuardarEnMemoria(usuario);
        }

        public static void ActualizarUsuarios(int id, Usuario usuario)
        {
            int indice = ListaUsuarios.FindIndex(a => a.Id == id);

            if(indice != -1)
            {
                ListaUsuarios[indice] = usuario;
            }

            GuardarEnMemoriaLista();
        }

        public static void EliminarUsuarios(int id)
        {
            Usuario Usuario = ListaUsuarios.FirstOrDefault(a => a.Id == id);
            Usuario.Activo = false;

            ActualizarUsuarios(Usuario.Id, Usuario);
        }

        public static void GuardarEnMemoria(Usuario usuario)
        {
            StreamWriter archivo = new StreamWriter("Usuarios.txt", true);
            archivo.WriteLine(usuario.Id + ";" + usuario.Nombre + ";" + usuario.Email + ";" + usuario.Domicilio + ";" + usuario.UsuarioLogin + ";" + usuario.Contrasena + ";" + Usuario.EsActivo(usuario.Activo) + ";" + Usuario.EsAdministrador(usuario.Admin));
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("Usuarios.txt");
            foreach(Usuario usuario in ListaUsuarios)
            {
                archivo.WriteLine(usuario.Id + ";" + usuario.Nombre + ";" + usuario.Email + ";" + usuario.Domicilio + ";" + usuario.UsuarioLogin + ";" + usuario.Contrasena + ";" + Usuario.EsActivo(usuario.Activo) + ";" + Usuario.EsAdministrador(usuario.Admin));
            }
            archivo.Close();
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            return ListaUsuarios;
        }

        private static int ObtenerUltimoId()
        {
            int ultimoId = 0;

            if(ListaUsuarios.Count > 0)
            {
                ultimoId = ListaUsuarios[ListaUsuarios.Count - 1].Id;

                ultimoId = ultimoId + 1;

                return ultimoId;
            }
            else
            {
                return 1;
            }
        }

        public static Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = ListaUsuarios.FirstOrDefault(a => a.Id == id);

            return usuario;
        }
        public static Usuario ObtenerUsuarioPorNombre(string nombre)
        {
            Usuario usuario = ListaUsuarios.FirstOrDefault(a => a.Nombre == nombre);

            return usuario;
        }

        public static Usuario ObtenerUsuarioPorNombreYContra(string login, string contrasena)
        {
            Usuario usuario = ListaUsuarios.FirstOrDefault(a => a.UsuarioLogin == login && a.Contrasena == contrasena);

            return usuario;
        }
        //}
    }
}
