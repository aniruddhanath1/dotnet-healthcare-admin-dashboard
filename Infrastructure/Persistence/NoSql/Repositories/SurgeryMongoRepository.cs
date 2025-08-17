using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class SurgeryMongoRepository : ISurgeryRepository
    {
        private readonly IMongoCollection<Surgery> _collection;

        public SurgeryMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Surgery>("Surgeries");
        }

        public async Task<IEnumerable<Surgery>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Surgery?> GetByIdAsync(int id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Surgery entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Surgery entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
