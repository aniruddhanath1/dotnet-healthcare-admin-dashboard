using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using laravel_admin_template.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class RequestMongoRepository : IRequestRepository
    {
        private readonly IMongoCollection<Request> _collection;
        public RequestMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Request>("Requests");
        }

        public async Task<IEnumerable<Request>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Request> GetByIdAsync(string requestId) => await _collection.Find(x => x.Id == requestId).FirstOrDefaultAsync();

        public async Task<Request> AddAsync(Request request)
        {
            await _collection.InsertOneAsync(request);
            return request;
        }

        public async Task<Request> UpdateAsync(Request request)
        {
            await _collection.ReplaceOneAsync(x => x.Id == request.Id, request);
            return request;
        }

        public async Task<bool> DeleteAsync(string requestId)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == requestId);
            return result.DeletedCount > 0;
        }
    }
}
