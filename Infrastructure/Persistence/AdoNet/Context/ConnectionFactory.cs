using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context
{
    public class ConnectionFactory
    {
        private readonly string _connectionString;
        public ConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
