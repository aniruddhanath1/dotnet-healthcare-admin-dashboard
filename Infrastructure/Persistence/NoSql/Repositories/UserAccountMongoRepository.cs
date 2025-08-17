using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class UserAccountMongoRepository : IUserAccountRepository
    {
        private readonly IMongoCollection<UserAccount> _collection;
        public UserAccountMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<UserAccount>("UserAccounts");
        }

        public async Task<IEnumerable<UserAccount>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<UserAccount> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<UserAccount> AddAsync(UserAccount userAccount)
        {
            await _collection.InsertOneAsync(userAccount);
            return userAccount;
        }

        public async Task<UserAccount> UpdateAsync(UserAccount userAccount)
        {
            await _collection.ReplaceOneAsync(x => x.Id == userAccount.Id, userAccount);
            return userAccount;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
