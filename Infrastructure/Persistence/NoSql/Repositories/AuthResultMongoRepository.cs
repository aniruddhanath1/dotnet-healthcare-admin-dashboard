using dotnet_admin_dashboard.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

using dotnet_admin_dashboard.Domain.Interfaces;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class AuthResultMongoRepository : IAuthResultRepository
    {
        private readonly IMongoCollection<AuthResult> _collection;
        public AuthResultMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<AuthResult>("AuthResults");
        }

        public async Task<IEnumerable<AuthResult>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<AuthResult> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<AuthResult> AddAsync(AuthResult authResult)
        {
            await _collection.InsertOneAsync(authResult);
            return authResult;
        }

        public async Task<AuthResult> UpdateAsync(AuthResult authResult)
        {
            await _collection.ReplaceOneAsync(x => x.Id == authResult.Id, authResult);
            return authResult;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
