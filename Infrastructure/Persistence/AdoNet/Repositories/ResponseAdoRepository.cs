using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class ResponseAdoRepository : IResponseRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public ResponseAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Response>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Responses";
                var result = await unitOfWork.Connection.QueryAsync<Response>(sql, transaction: unitOfWork.Transaction);
                Commit(unitOfWork);
                return result;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<Response> GetByIdAsync(string requestId, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Responses WHERE RequestId=@RequestId";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<Response>(sql, new { RequestId = requestId }, unitOfWork.Transaction);
                Commit(unitOfWork);
                return result;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<Response> AddAsync(Response response, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO Responses (RequestId, Timestamp, Success, Message, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.RequestId
                        VALUES (@RequestId, @Timestamp, @Success, @Message, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                response.RequestId = await unitOfWork.Connection.ExecuteScalarAsync<string>(sql, response, unitOfWork.Transaction);
                Commit(unitOfWork);
                return response;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<Response> UpdateAsync(Response response, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE Responses SET Timestamp=@Timestamp, Success=@Success, Message=@Message, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE RequestId=@RequestId";
                await unitOfWork.Connection.ExecuteAsync(sql, response, unitOfWork.Transaction);
                Commit(unitOfWork);
                return response;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        public async Task<bool> DeleteAsync(string requestId, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "DELETE FROM Responses WHERE RequestId=@RequestId";
                var affected = await unitOfWork.Connection.ExecuteAsync(sql, new { RequestId = requestId }, unitOfWork.Transaction);
                Commit(unitOfWork);
                return affected > 0;
            }
            catch
            {
                Rollback(unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(unitOfWork);
            }
        }

        // Transaction management methods
        public void Commit(AdoNetUnitOfWork unitOfWork)
        {
            unitOfWork.Commit();
        }

        public void Rollback(AdoNetUnitOfWork unitOfWork)
        {
            unitOfWork.Rollback();
        }

        public void DisposeUnitOfWork(AdoNetUnitOfWork unitOfWork)
        {
            unitOfWork.Dispose();
        }
    }
}
