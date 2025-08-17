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
    public class BedAdoRepository : IBedRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly AdoNetUnitOfWork _unitOfWork;

        public BedAdoRepository(ConnectionFactory connectionFactory, AdoNetUnitOfWork unitOfWork)
        {
            _connectionFactory = connectionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Bed>> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM Beds";
                var result = await _unitOfWork.Connection.QueryAsync<Bed>(sql, transaction: _unitOfWork.Transaction);
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

        public async Task<Bed> GetByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Beds WHERE Id=@Id";
                var result = await _unitOfWork.Connection.QuerySingleOrDefaultAsync<Bed>(sql, new { Id = id }, _unitOfWork.Transaction);
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

        public async Task<Bed> AddAsync(Bed bed)
        {
            try
            {
                var sql = @"INSERT INTO Beds (RoomId, Status, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@RoomId, @Status, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                bed.Id = await _unitOfWork.Connection.ExecuteScalarAsync<int>(sql, bed, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return bed;
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

        public async Task<Bed> UpdateAsync(Bed bed)
        {
            try
            {
                var sql = @"UPDATE Beds SET RoomId=@RoomId, Status=@Status, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await _unitOfWork.Connection.ExecuteAsync(sql, bed, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return bed;
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Beds WHERE Id=@Id";
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
