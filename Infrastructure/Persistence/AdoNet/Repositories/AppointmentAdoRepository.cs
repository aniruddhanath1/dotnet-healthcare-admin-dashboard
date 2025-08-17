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
    public class AppointmentAdoRepository : IAppointmentAdoRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly AdoNetUnitOfWork _unitOfWork;

        public AppointmentAdoRepository(ConnectionFactory connectionFactory, AdoNetUnitOfWork unitOfWork)
        {
            _connectionFactory = connectionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM Appointments";
                var result = await _unitOfWork.Connection.QueryAsync<Appointment>(sql, transaction: _unitOfWork.Transaction);
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

        public async Task<Appointment> GetByIdAsync(string id)
        {
            try
            {
                var sql = "SELECT * FROM Appointments WHERE Id=@Id";
                var result = await _unitOfWork.Connection.QuerySingleOrDefaultAsync<Appointment>(sql, new { Id = id }, _unitOfWork.Transaction);
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

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            try
            {
                var sql = @"INSERT INTO Appointments (PatientId, DoctorId, Date, Reason, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@PatientId, @DoctorId, @Date, @Reason, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                appointment.Id = await _unitOfWork.Connection.ExecuteScalarAsync<int>(sql, appointment, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return appointment;
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

        public async Task<Appointment> UpdateAsync(Appointment appointment)
        {
            try
            {
                var sql = @"UPDATE Appointments SET PatientId=@PatientId, DoctorId=@DoctorId, Date=@Date, Reason=@Reason, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await _unitOfWork.Connection.ExecuteAsync(sql, appointment, _unitOfWork.Transaction);
                Commit(_unitOfWork);
                return appointment;
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
                var sql = "DELETE FROM Appointments WHERE Id=@Id";
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
