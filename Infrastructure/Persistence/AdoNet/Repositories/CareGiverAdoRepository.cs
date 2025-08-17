using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.UnitOfWork;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class CareGiverAdoRepository : ICareGiverRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly AdoNetUnitOfWork _unitOfWork;

        public CareGiverAdoRepository(ConnectionFactory connectionFactory, AdoNetUnitOfWork unitOfWork)
        {
            _connectionFactory = connectionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CareGiver>> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM CareGivers";
                var result = await _unitOfWork.Connection.QueryAsync<CareGiver>(sql, transaction: _unitOfWork.Transaction);
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

        public async Task<CareGiver> GetByIdAsync(string id)
        {
            try
            {
                var sql = "SELECT * FROM CareGivers WHERE Id=@Id";
                var result = await _unitOfWork.Connection.QuerySingleOrDefaultAsync<CareGiver>(sql, new { Id = id }, _unitOfWork.Transaction);
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

        public async Task AddAsync(CareGiver careGiver)
        {
            try
            {
                var sql = @"INSERT INTO CareGivers (Name, Relationship, ContactNumber, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        VALUES (@Name, @Relationship, @ContactNumber, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                await _unitOfWork.Connection.ExecuteAsync(sql, careGiver, _unitOfWork.Transaction);
                Commit(_unitOfWork);
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

        public async Task UpdateAsync(CareGiver careGiver)
        {
            try
            {
                var sql = @"UPDATE CareGivers SET Name=@Name, Relationship=@Relationship, ContactNumber=@ContactNumber, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await _unitOfWork.Connection.ExecuteAsync(sql, careGiver, _unitOfWork.Transaction);
                Commit(_unitOfWork);
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

        public async Task DeleteAsync(string id)
        {
            try
            {
                var sql = "DELETE FROM CareGivers WHERE Id=@Id";
                await _unitOfWork.Connection.ExecuteAsync(sql, new { Id = id }, _unitOfWork.Transaction);
                Commit(_unitOfWork);
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
