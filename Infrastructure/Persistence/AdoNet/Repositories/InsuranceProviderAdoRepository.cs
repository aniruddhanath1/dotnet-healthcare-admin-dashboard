using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class InsuranceProviderAdoRepository : IInsuranceProviderRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public InsuranceProviderAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<InsuranceProvider>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM InsuranceProviders";
                var result = await unitOfWork.Connection.QueryAsync<InsuranceProvider>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<InsuranceProvider> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM InsuranceProviders WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<InsuranceProvider>(sql, new { Id = id }, unitOfWork.Transaction);
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

        public async Task<InsuranceProvider> AddAsync(InsuranceProvider provider, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO InsuranceProviders (Name, ContactNumber, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@Name, @ContactNumber, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                provider.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, provider, unitOfWork.Transaction);
                Commit(unitOfWork);
                return provider;
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

        public async Task<InsuranceProvider> UpdateAsync(InsuranceProvider provider, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE InsuranceProviders SET Name=@Name, ContactNumber=@ContactNumber, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, provider, unitOfWork.Transaction);
                Commit(unitOfWork);
                return provider;
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
                var sql = "DELETE FROM InsuranceProviders WHERE Id=@Id";
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
