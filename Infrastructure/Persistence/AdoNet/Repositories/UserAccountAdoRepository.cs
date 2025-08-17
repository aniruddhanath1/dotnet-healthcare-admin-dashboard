using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class UserAccountAdoRepository : IUserAccountRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public UserAccountAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<UserAccount>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM UserAccounts";
                var result = await unitOfWork.Connection.QueryAsync<UserAccount>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<UserAccount> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM UserAccounts WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<UserAccount>(sql, new { Id = id }, unitOfWork.Transaction);
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

        public async Task<UserAccount> AddAsync(UserAccount userAccount, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO UserAccounts (Username, PasswordHash, Role, Status, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id
                        VALUES (@Username, @PasswordHash, @Role, @Status, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                userAccount.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, userAccount, unitOfWork.Transaction);
                Commit(unitOfWork);
                return userAccount;
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

        public async Task<UserAccount> UpdateAsync(UserAccount userAccount, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE UserAccounts SET Username=@Username, PasswordHash=@PasswordHash, Role=@Role, Status=@Status, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, userAccount, unitOfWork.Transaction);
                Commit(unitOfWork);
                return userAccount;
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
                var sql = "DELETE FROM UserAccounts WHERE Id=@Id";
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
