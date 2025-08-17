using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Context;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories
{
    public class MedicationAdoRepository : IMedicationRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public MedicationAdoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Medication>> GetAllAsync(AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Medications";
                var result = await unitOfWork.Connection.QueryAsync<Medication>(sql, transaction: unitOfWork.Transaction);
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

        public async Task<Medication> GetByIdAsync(int id, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = "SELECT * FROM Medications WHERE Id=@Id";
                var result = await unitOfWork.Connection.QuerySingleOrDefaultAsync<Medication>(sql, new { Id = id }, unitOfWork.Transaction);
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

        public async Task<Medication> AddAsync(Medication medication, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"INSERT INTO Medications (Name, Dosage, Frequency, CreatedBy, CreatedDateTime, LastModifiedBy, LastModifiedDateTime)
                        OUTPUT INSERTED.Id VALUES (@Name, @Dosage, @Frequency, @CreatedBy, @CreatedDateTime, @LastModifiedBy, @LastModifiedDateTime)";
                medication.Id = await unitOfWork.Connection.ExecuteScalarAsync<int>(sql, medication, unitOfWork.Transaction);
                Commit(unitOfWork);
                return medication;
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

        public async Task<Medication> UpdateAsync(Medication medication, AdoNetUnitOfWork unitOfWork)
        {
            try
            {
                var sql = @"UPDATE Medications SET Name=@Name, Dosage=@Dosage, Frequency=@Frequency, LastModifiedBy=@LastModifiedBy, LastModifiedDateTime=@LastModifiedDateTime WHERE Id=@Id";
                await unitOfWork.Connection.ExecuteAsync(sql, medication, unitOfWork.Transaction);
                Commit(unitOfWork);
                return medication;
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
                var sql = "DELETE FROM Medications WHERE Id=@Id";
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
