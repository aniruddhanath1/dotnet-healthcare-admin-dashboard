using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using DotNetAdminPanel.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class AmbulanceMongoRepository : IAmbulanceMongoRepository
    {
        private readonly IMongoCollection<Ambulance> _collection;
        public AmbulanceMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Ambulance>("Ambulances");
        }
        public async Task<IEnumerable<Ambulance>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Ambulance> GetByIdAsync(string id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Ambulance> AddAsync(Ambulance ambulance)
        {
            await _collection.InsertOneAsync(ambulance);
            return ambulance;
        }
        public async Task<Ambulance> UpdateAsync(Ambulance ambulance)
        {
            await _collection.ReplaceOneAsync(e => e.Id == ambulance.Id, ambulance);
            return ambulance;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
