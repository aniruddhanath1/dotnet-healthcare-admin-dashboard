using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class RoomMongoRepository : IRoomRepository
    {
        private readonly IMongoCollection<Room> _collection;
        public RoomMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Room>("Rooms");
        }
        public async Task<IEnumerable<Room>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Room> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Room> AddAsync(Room room)
        {
            await _collection.InsertOneAsync(room);
            return room;
        }
        public async Task<Room> UpdateAsync(Room room)
        {
            await _collection.ReplaceOneAsync(e => e.Id == room.Id, room);
            return room;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
