using Dapper;
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
        public async Task Guardar(Pedido pedido)
        {
            using var connection = new SqlConnection(connectionString);

            var id = await connection.QuerySingleAsync<int>(
            @"INSERT INTO Pedido (Id, Nombrecliente, Pedido, Total)
                VALUES (@Id, @Nombrecliente, @Pedido, @Total)
                SELECT SCOPE_IDENTITY();", pedido
            );
            pedido.Id = id;
        }
    }
}
