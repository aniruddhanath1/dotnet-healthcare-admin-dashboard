using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class DischargeSummaryMongoRepository : IDischargeSummaryRepository
    {
        private readonly IMongoCollection<DischargeSummary> _collection;
        public DischargeSummaryMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<DischargeSummary>("DischargeSummaries");
        }
        public async Task<IEnumerable<DischargeSummary>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<DischargeSummary> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<DischargeSummary> AddAsync(DischargeSummary summary)
        {
            await _collection.InsertOneAsync(summary);
            return summary;
        }
        public async Task<DischargeSummary> UpdateAsync(DischargeSummary summary)
        {
            await _collection.ReplaceOneAsync(e => e.Id == summary.Id, summary);
            return summary;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
