using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class InsuranceProviderMongoRepository : IInsuranceProviderRepository
    {
        private readonly IMongoCollection<InsuranceProvider> _collection;
        public InsuranceProviderMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<InsuranceProvider>("InsuranceProviders");
        }
        public async Task<IEnumerable<InsuranceProvider>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<InsuranceProvider> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<InsuranceProvider> AddAsync(InsuranceProvider provider)
        {
            await _collection.InsertOneAsync(provider);
            return provider;
        }
        public async Task<InsuranceProvider> UpdateAsync(InsuranceProvider provider)
        {
            await _collection.ReplaceOneAsync(e => e.Id == provider.Id, provider);
            return provider;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
