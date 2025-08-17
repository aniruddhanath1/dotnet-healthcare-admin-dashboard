using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class NurseMongoRepository : INurseRepository
    {
        private readonly IMongoCollection<Nurse> _collection;
        public NurseMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Nurse>("Nurses");
        }

        public async Task<IEnumerable<Nurse>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Nurse> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Nurse> AddAsync(Nurse nurse)
        {
            await _collection.InsertOneAsync(nurse);
            return nurse;
        }

        public async Task<Nurse> UpdateAsync(Nurse nurse)
        {
            await _collection.ReplaceOneAsync(x => x.Id == nurse.Id, nurse);
            return nurse;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
