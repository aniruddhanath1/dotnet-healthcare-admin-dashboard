using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class EquipmentMongoRepository : IEquipmentRepository
    {
        private readonly IMongoCollection<Equipment> _collection;
        public EquipmentMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Equipment>("Equipments");
        }
        public async Task<IEnumerable<Equipment>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Equipment> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Equipment> AddAsync(Equipment equipment)
        {
            await _collection.InsertOneAsync(equipment);
            return equipment;
        }
        public async Task<Equipment> UpdateAsync(Equipment equipment)
        {
            await _collection.ReplaceOneAsync(e => e.Id == equipment.Id, equipment);
            return equipment;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
