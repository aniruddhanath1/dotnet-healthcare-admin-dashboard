using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class CareGiverMongoRepository : ICareGiverRepository
    {
        private readonly IMongoCollection<CareGiver> _collection;
        public CareGiverMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<CareGiver>("CareGivers");
        }

        public async Task<IEnumerable<CareGiver>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<CareGiver> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<CareGiver> AddAsync(CareGiver careGiver)
        {
            await _collection.InsertOneAsync(careGiver);
            return careGiver;
        }

        public async Task<CareGiver> UpdateAsync(CareGiver careGiver)
        {
            await _collection.ReplaceOneAsync(x => x.Id == careGiver.Id, careGiver);
            return careGiver;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
