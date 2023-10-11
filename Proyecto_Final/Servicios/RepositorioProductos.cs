using Microsoft.Data.SqlClient;
using Proyecto_Final.Models;

namespace Proyecto_Final.Servicios
{
    public interface IRepositorioProductos
    {

    }
    public class RepositorioProductos : IRepositorioProducto
    {
        private readonly string connectionString;



        public RepositorioProductos(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task Agregarproducto(Productos productos)
        {
            using var connection = new SqlConnection(connectionString);
        }
    }
}
