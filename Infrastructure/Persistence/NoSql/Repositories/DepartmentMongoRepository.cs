using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class DepartmentMongoRepository : IDepartmentRepository
    {
        private readonly IMongoCollection<Department> _collection;
        public DepartmentMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Department>("Departments");
        }
        public async Task<IEnumerable<Department>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Department> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Department> AddAsync(Department department)
        {
            await _collection.InsertOneAsync(department);
            return department;
        }
        public async Task<Department> UpdateAsync(Department department)
        {
            await _collection.ReplaceOneAsync(e => e.Id == department.Id, department);
            return department;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
