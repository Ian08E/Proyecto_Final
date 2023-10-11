using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMascota_v2.Modelo;
using TiendaMascota_v2.Repositorio;

namespace TiendaMascota_v2.Controlador
{
    public class UsuarioControlador
    {
        public static void IniciarRepositorio()
        {
            UsuarioRepositorio.IniciarRepositorio();
        }

        public static void AgregarUsuarios(Usuario usuario)
        {
            // Validaciones: ValidarUsuario();

            UsuarioRepositorio.AgregarUsuarios(usuario);
        }

        public static void ActualizarUsuarios(int id, Usuario usuario)
        {
            UsuarioRepositorio.ActualizarUsuarios(id, usuario);
        }

        public static void EliminarUsuarios(int id)
        {
            UsuarioRepositorio.EliminarUsuarios(id);
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            return UsuarioRepositorio.ObtenerUsuarios();
        }

        public static int ObtenerUltimoId()
        {
            return UsuarioRepositorio.UltimoId;
        }

        public static bool ValidarUsuario(string nombre, string contrasena)
        {
            var listaUsuarios = UsuarioRepositorio.ListaUsuarios;

            foreach (var usuario in listaUsuarios)
            {
                if(nombre.Equals(usuario.UsuarioLogin) && contrasena.Equals(usuario.Contrasena))
                {
                    return true;
                }
            }

            return false;
        }

        public static Usuario ObtenerUsuarioPorNombreYContra(string login, string contrasena)
        {
            return UsuarioRepositorio.ObtenerUsuarioPorNombreYContra(login, contrasena);
        }
    }
}
