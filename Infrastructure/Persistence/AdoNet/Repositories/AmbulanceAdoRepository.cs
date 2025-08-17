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
    public class AmbulanceAdoRepository : IAmbulanceAdoRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly AdoNetUnitOfWork _unitOfWork;
        public AmbulanceAdoRepository(ConnectionFactory connectionFactory, AdoNetUnitOfWork unitOfWork)
        {
            _connectionFactory = connectionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ambulance>> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM Ambulances";
                var result = await SqlMapper.QueryAsync<Ambulance>(
                    _unitOfWork.Connection, sql, null, _unitOfWork.Transaction);
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

        public async Task<Ambulance> GetByIdAsync(Guid id)
        {
            try
            {
                var sql = "SELECT * FROM Ambulances WHERE Id=@Id";
                var result = await _unitOfWork.Connection.QuerySingleOrDefaultAsync<Ambulance>(sql, new { Id = id }, _unitOfWork.Transaction);
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

        public async Task<Ambulance> AddAsync(Ambulance ambulance)
        {
            try
            {
                var sql = @"INSERT INTO Ambulances (PlateNumber, Status, Location, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@PlateNumber, @Status, @Location, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                var insertedId = await _unitOfWork.Connection.ExecuteScalarAsync<Guid>(sql, ambulance, _unitOfWork.Transaction);
                ambulance.Id = insertedId;
                Commit(_unitOfWork);
                return ambulance;
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

        public async Task<Ambulance> UpdateAsync(Ambulance ambulance)
        {
            try
            {
                var sql = @"UPDATE Ambulances SET PlateNumber=@PlateNumber, Status=@Status, Location=@Location, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await _unitOfWork.Connection.ExecuteAsync(sql, ambulance, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return ambulance;
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var sql = "DELETE FROM Ambulances WHERE Id=@Id";
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
