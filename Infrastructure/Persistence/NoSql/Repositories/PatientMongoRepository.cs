using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class PatientMongoRepository : IPatientRepository
    {
        private readonly IMongoCollection<Patient> _collection;
        public PatientMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Patient>("Patients");
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Patient> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Patient> AddAsync(Patient patient)
        {
            await _collection.InsertOneAsync(patient);
            return patient;
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            await _collection.ReplaceOneAsync(x => x.Id == patient.Id, patient);
            return patient;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
