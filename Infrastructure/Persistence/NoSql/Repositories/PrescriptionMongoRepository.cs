using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class PrescriptionMongoRepository : IPrescriptionRepository
    {
        private readonly IMongoCollection<Prescription> _collection;
        public PrescriptionMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Prescription>("Prescriptions");
        }
        public async Task<IEnumerable<Prescription>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Prescription> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Prescription> AddAsync(Prescription prescription)
        {
            await _collection.InsertOneAsync(prescription);
            return prescription;
        }
        public async Task<Prescription> UpdateAsync(Prescription prescription)
        {
            await _collection.ReplaceOneAsync(e => e.Id == prescription.Id, prescription);
            return prescription;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
