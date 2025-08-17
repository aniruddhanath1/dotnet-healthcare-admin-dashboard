using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class MedicationMongoRepository : IMedicationRepository
    {
        private readonly IMongoCollection<Medication> _collection;
        public MedicationMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Medication>("Medications");
        }
        public async Task<IEnumerable<Medication>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Medication> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Medication> AddAsync(Medication medication)
        {
            await _collection.InsertOneAsync(medication);
            return medication;
        }
        public async Task<Medication> UpdateAsync(Medication medication)
        {
            await _collection.ReplaceOneAsync(e => e.Id == medication.Id, medication);
            return medication;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
