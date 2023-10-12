using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class Usuario
    {
        public int Id;
        public string Nombre;
        public string Email;
        public string Domicilio;
        public string UsuarioLogin;
        public string Contrasena;
        public bool Activo;
        public bool Admin;

    
        public Usuario(string[] lineaUsuario)
        {
            this.Id = int.Parse(lineaUsuario[0]);
            this.Nombre = lineaUsuario[1];
            this.Email = lineaUsuario[2];
            this.Domicilio = lineaUsuario[3];
            this.UsuarioLogin = lineaUsuario[4];
            this.Contrasena = lineaUsuario[5];
            this.Activo = EsActivo(lineaUsuario[6]);
            this.Admin = EsAdministrador(lineaUsuario[7]);
        }

        public static bool EsActivo(string esActivo)
        {
            if(esActivo.Equals("SI"))
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

        public static bool EsAdministrador(string esAdministrador)
        {
            if (esAdministrador.Equals("SI"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string EsAdministrador(bool esAdministrador)
        {
            if (esAdministrador)
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
