using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class ErrorResponseAdoRepository : IErrorResponseRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public ErrorResponseAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ErrorResponse>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM ErrorResponses";
                var result = await unitOfWork.Connection.QueryAsync<ErrorResponse>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<ErrorResponse> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM ErrorResponses WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<ErrorResponse>(sql, new { Id = id }, unitOfWork.Transaction);
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

        public async Task<ErrorResponse> AddAsync(ErrorResponse errorResponse, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO ErrorResponses (ErrorCode, Details, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@ErrorCode, @Details, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                errorResponse.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, errorResponse, unitOfWork.Transaction);
                Commit(unitOfWork);
                return errorResponse;
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

        public async Task<ErrorResponse> UpdateAsync(ErrorResponse errorResponse, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE ErrorResponses SET ErrorCode=@ErrorCode, Details=@Details, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, errorResponse, unitOfWork.Transaction);
                Commit(unitOfWork);
                return errorResponse;
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

        public async Task<bool> DeleteAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "DELETE FROM ErrorResponses WHERE Id=@Id";
                var affected = await unitOfWork.Connection.ExecuteAsync(sql, new { Id = id }, unitOfWork.Transaction);
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
