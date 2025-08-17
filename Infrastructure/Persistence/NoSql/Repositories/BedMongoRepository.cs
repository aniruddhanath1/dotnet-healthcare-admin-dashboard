using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class BedMongoRepository : IBedRepository
    {
        private readonly IMongoCollection<Bed> _collection;
        public BedMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Bed>("Beds");
        }
        public async Task<IEnumerable<Bed>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Bed> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Bed> AddAsync(Bed bed)
        {
            await _collection.InsertOneAsync(bed);
            return bed;
        }
        public async Task<Bed> UpdateAsync(Bed bed)
        {
            await _collection.ReplaceOneAsync(e => e.Id == bed.Id, bed);
            return bed;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
