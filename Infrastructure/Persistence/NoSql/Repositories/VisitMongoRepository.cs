using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class VisitMongoRepository : IVisitRepository
    {
        private readonly IMongoCollection<Visit> _collection;

        public VisitMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Visit>("Visits");
        }

        public async Task<IEnumerable<Visit>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Visit?> GetByIdAsync(int id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Visit entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Visit entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
