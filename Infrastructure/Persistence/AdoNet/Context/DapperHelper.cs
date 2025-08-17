using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context
{
    public static class DapperHelper
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection connection, string sql, object param = null, IDbTransaction transaction = null)
        {
            return await connection.QueryAsync<T>(sql, param, transaction);
        }

        public static async Task<T> QuerySingleAsync<T>(this IDbConnection connection, string sql, object param = null, IDbTransaction transaction = null)
        {
            return await connection.QuerySingleOrDefaultAsync<T>(sql, param, transaction);
        }

        public static async Task<int> ExecuteAsync(this IDbConnection connection, string sql, object param = null, IDbTransaction transaction = null)
        {
            return await connection.ExecuteAsync(sql, param, transaction);
        }
    }
}
