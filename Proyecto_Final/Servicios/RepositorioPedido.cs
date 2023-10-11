using Microsoft.Data.SqlClient;
using Proyecto_Final.Models;

namespace Proyecto_Final.Servicios
{
    public interface IRepositorioPedido
    {

    }
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly string connectionString;



        public RepositorioPedido(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task Guardar(Producto producto)
        {
            using var connection = new SqlConnection(connectionString);
        }
    }
}
