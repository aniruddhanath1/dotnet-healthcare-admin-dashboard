using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class LabTestMongoRepository : ILabTestRepository
    {
        private readonly IMongoCollection<LabTest> _collection;
        public LabTestMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<LabTest>("LabTests");
        }
        public async Task<IEnumerable<LabTest>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<LabTest> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<LabTest> AddAsync(LabTest test)
        {
            await _collection.InsertOneAsync(test);
            return test;
        }
        public async Task<LabTest> UpdateAsync(LabTest test)
        {
            await _collection.ReplaceOneAsync(e => e.Id == test.Id, test);
            return test;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
