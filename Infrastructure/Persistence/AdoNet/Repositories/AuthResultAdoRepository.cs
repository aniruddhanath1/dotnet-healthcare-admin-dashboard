using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.UnitOfWork;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class AuthResultAdoRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly AdoNetUnitOfWork _unitOfWork;

        public AuthResultAdoRepository(ConnectionFactory connectionFactory, AdoNetUnitOfWork unitOfWork)
        {
            _connectionFactory = connectionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AuthResult>> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM AuthResults";
                var result = await _unitOfWork.Connection.QueryAsync<AuthResult>(sql, transaction: _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return result;
            }
            catch
            {
                Rollback(_unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(_unitOfWork);
            }
        }

        public async Task<AuthResult> GetByIdAsync(string id)
        {
            try
            {
                var sql = "SELECT * FROM AuthResults WHERE Id=@Id";
                var result = await _unitOfWork.Connection.QuerySingleOrDefaultAsync<AuthResult>(sql, new { Id = id }, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return result;
            }
            catch
            {
                Rollback(_unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(_unitOfWork);
            }
        }

        public async Task<AuthResult> AddAsync(AuthResult authResult)
        {
            try
            {
                var sql = @"INSERT INTO AuthResults (UserId, Token, ExpiresAt, IsSuccess, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@UserId, @Token, @ExpiresAt, @IsSuccess, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                authResult.Id = await _unitOfWork.Connection.ExecuteScalarAsync<int>(sql, authResult, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return authResult;
            }
            catch
            {
                Rollback(_unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(_unitOfWork);
            }
        }

        public async Task<AuthResult> UpdateAsync(AuthResult authResult)
        {
            try
            {
                var sql = @"UPDATE AuthResults SET UserId=@UserId, Token=@Token, ExpiresAt=@ExpiresAt, IsSuccess=@IsSuccess, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await _unitOfWork.Connection.ExecuteAsync(sql, authResult, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return authResult;
            }
            catch
            {
                Rollback(_unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(_unitOfWork);
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var sql = "DELETE FROM AuthResults WHERE Id=@Id";
                var affected = await _unitOfWork.Connection.ExecuteAsync(sql, new { Id = id }, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return affected > 0;
            }
            catch
            {
                Rollback(_unitOfWork);
                throw;
            }
            finally
            {
                DisposeUnitOfWork(_unitOfWork);
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
