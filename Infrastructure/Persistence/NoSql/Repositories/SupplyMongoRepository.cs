using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class SupplyMongoRepository : ISupplyRepository
    {
        private readonly IMongoCollection<Supply> _collection;
        public SupplyMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Supply>("Supplies");
        }
        public async Task<IEnumerable<Supply>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Supply> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Supply> AddAsync(Supply supply)
        {
            await _collection.InsertOneAsync(supply);
            return supply;
        }
        public async Task<Supply> UpdateAsync(Supply supply)
        {
            await _collection.ReplaceOneAsync(e => e.Id == supply.Id, supply);
            return supply;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
