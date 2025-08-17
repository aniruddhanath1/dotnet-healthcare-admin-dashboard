using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class RequestAdoRepository : IRequestRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public RequestAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Request>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Requests";
                var result = await unitOfWork.Connection.QueryAsync<Request>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<Request> GetByIdAsync(string requestId, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Requests WHERE RequestId=@RequestId";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<Request>(sql, new { RequestId = requestId }, unitOfWork.Transaction);
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

        public async Task<Request> AddAsync(Request request, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO Requests (RequestId, Timestamp, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.RequestId VALUES (@RequestId, @Timestamp, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                request.RequestId = await unitOfWork.Connection.ExecuteScalarAsync<string>(sql, request, unitOfWork.Transaction);
                Commit(unitOfWork);
                return request;
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

        public async Task<Request> UpdateAsync(Request request, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE Requests SET Timestamp=@Timestamp, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE RequestId=@RequestId";
                await unitOfWork.Connection.ExecuteAsync(sql, request, unitOfWork.Transaction);
                Commit(unitOfWork);
                return request;
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
                var sql = "DELETE FROM Requests WHERE RequestId=@RequestId";
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
