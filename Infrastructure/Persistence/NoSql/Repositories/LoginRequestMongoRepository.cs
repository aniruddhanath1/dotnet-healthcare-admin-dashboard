using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class LoginRequestMongoRepository : ILoginRequestRepository
    {
        private readonly IMongoCollection<LoginRequestDto> _collection;
        public LoginRequestMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<LoginRequestDto>("LoginRequests");
        }
        public async Task<IEnumerable<LoginRequestDto>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<LoginRequestDto> GetByIdAsync(string id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<LoginRequestDto> AddAsync(LoginRequestDto loginRequest)
        {
            await _collection.InsertOneAsync(loginRequest);
            return loginRequest;
        }
        public async Task<LoginRequestDto> UpdateAsync(LoginRequestDto loginRequest)
        {
            await _collection.ReplaceOneAsync(e => e.Id == loginRequest.Id, loginRequest);
            return loginRequest;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
