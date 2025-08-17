using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using laravel_admin_template.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        public UserMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("Users");
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<User> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();


        public async Task<User> AddAsync(User user)
        {
            await _collection.InsertOneAsync(user);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            await _collection.ReplaceOneAsync(x => x.Id == user.Id, user);
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
