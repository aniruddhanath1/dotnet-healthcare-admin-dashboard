using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class SuccessResponseMongoRepository : ISuccessResponseRepository
    {
        private readonly IMongoCollection<SuccessResponse> _collection;
        public SuccessResponseMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<SuccessResponse>("SuccessResponses");
        }

        public async Task<IEnumerable<SuccessResponse>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<SuccessResponse> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<SuccessResponse> AddAsync(SuccessResponse successResponse)
        {
            await _collection.InsertOneAsync(successResponse);
            return successResponse;
        }

        public async Task<SuccessResponse> UpdateAsync(SuccessResponse successResponse)
        {
            await _collection.ReplaceOneAsync(x => x.Id == successResponse.Id, successResponse);
            return successResponse;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
