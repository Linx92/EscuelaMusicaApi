using Microsoft.Data.SqlClient;
using System.Data;

namespace EscuelaMusicaAPI.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
    public class SqlConnectionFactory:ISqlConnectionFactory
    {
        private readonly string? _connectionString;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
