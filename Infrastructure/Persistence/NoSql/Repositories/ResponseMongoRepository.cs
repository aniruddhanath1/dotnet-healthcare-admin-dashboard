using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using laravel_admin_template.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class ResponseMongoRepository : IResponseRepository
    {
        private readonly IMongoCollection<Response> _collection;
        public ResponseMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Response>("Responses");
        }

        public async Task<IEnumerable<Response>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Response> GetByIdAsync(string requestId) => await _collection.Find(x => x.Id == requestId).FirstOrDefaultAsync();

        public async Task<Response> AddAsync(Response response)
        {
            await _collection.InsertOneAsync(response);
            return response;
        }

        public async Task<Response> UpdateAsync(Response response)
        {
            await _collection.ReplaceOneAsync(x => x.Id == response.Id, response);
            return response;
        }

        public async Task<bool> DeleteAsync(string requestId)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == requestId);
            return result.DeletedCount > 0;
        }
    }
}
