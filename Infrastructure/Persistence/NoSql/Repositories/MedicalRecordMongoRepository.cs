using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class MedicalRecordMongoRepository : IMedicalRecordRepository
    {
        private readonly IMongoCollection<MedicalRecord> _collection;
        public MedicalRecordMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<MedicalRecord>("MedicalRecords");
        }
        public async Task<IEnumerable<MedicalRecord>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<MedicalRecord> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<MedicalRecord> AddAsync(MedicalRecord record)
        {
            await _collection.InsertOneAsync(record);
            return record;
        }
        public async Task<MedicalRecord> UpdateAsync(MedicalRecord record)
        {
            await _collection.ReplaceOneAsync(e => e.Id == record.Id, record);
            return record;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
