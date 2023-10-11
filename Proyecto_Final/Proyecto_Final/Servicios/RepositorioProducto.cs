using Microsoft.Data.SqlClient;
using Proyecto_Final.Models;

namespace Proyecto_Final.Servicios
{
    public interface IRepositorioProducto
    {

    }
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly string connectionString;



        public RepositorioProducto(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task Crear(Producto producto)
        {
            using var connection = new SqlConnection(connectionString);
        }
    }
}
