using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class StaffMongoRepository : IStaffRepository
    {
        private readonly IMongoCollection<Staff> _collection;
        public StaffMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Staff>("Staffs");
        }

        public async Task<IEnumerable<Staff>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Staff> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Staff> AddAsync(Staff staff)
        {
            await _collection.InsertOneAsync(staff);
            return staff;
        }

        public async Task<Staff> UpdateAsync(Staff staff)
        {
            await _collection.ReplaceOneAsync(x => x.Id == staff.Id, staff);
            return staff;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
