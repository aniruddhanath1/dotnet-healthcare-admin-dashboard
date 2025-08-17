using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class ShiftMongoRepository : IShiftRepository
    {
        private readonly IMongoCollection<Shift> _collection;
        public ShiftMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Shift>("Shifts");
        }
        public async Task<IEnumerable<Shift>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Shift> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Shift> AddAsync(Shift shift)
        {
            await _collection.InsertOneAsync(shift);
            return shift;
        }
        public async Task<Shift> UpdateAsync(Shift shift)
        {
            await _collection.ReplaceOneAsync(e => e.Id == shift.Id, shift);
            return shift;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
