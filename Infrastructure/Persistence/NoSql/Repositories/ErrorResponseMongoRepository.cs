using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class ErrorResponseMongoRepository : IErrorResponseRepository
    {
        private readonly IMongoCollection<ErrorResponse> _collection;
        public ErrorResponseMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ErrorResponse>("ErrorResponses");
        }

        public async Task<IEnumerable<ErrorResponse>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<ErrorResponse> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<ErrorResponse> AddAsync(ErrorResponse errorResponse)
        {
            await _collection.InsertOneAsync(errorResponse);
            return errorResponse;
        }

        public async Task<ErrorResponse> UpdateAsync(ErrorResponse errorResponse)
        {
            await _collection.ReplaceOneAsync(x => x.Id == errorResponse.Id, errorResponse);
            return errorResponse;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
