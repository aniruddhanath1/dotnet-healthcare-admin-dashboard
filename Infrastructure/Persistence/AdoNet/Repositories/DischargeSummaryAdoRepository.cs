using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class DischargeSummaryAdoRepository : IDischargeSummaryRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public DischargeSummaryAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<DischargeSummary>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM DischargeSummaries";
                var result = await unitOfWork.Connection.QueryAsync<DischargeSummary>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<DischargeSummary> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM DischargeSummaries WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<DischargeSummary>(sql, new { Id = id }, unitOfWork.Transaction);
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

        public async Task<DischargeSummary> AddAsync(DischargeSummary summary, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO DischargeSummaries (PatientId, Summary, Date, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@PatientId, @Summary, @Date, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                summary.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, summary, unitOfWork.Transaction);
                Commit(unitOfWork);
                return summary;
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

        public async Task<DischargeSummary> UpdateAsync(DischargeSummary summary, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE DischargeSummaries SET PatientId=@PatientId, Summary=@Summary, Date=@Date, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, summary, unitOfWork.Transaction);
                Commit(unitOfWork);
                return summary;
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
                var sql = "DELETE FROM DischargeSummaries WHERE Id=@Id";
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
