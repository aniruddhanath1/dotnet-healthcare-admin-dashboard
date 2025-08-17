using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class ReferralMongoRepository : IReferralRepository
    {
        private readonly IMongoCollection<Referral> _collection;
        public ReferralMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Referral>("Referrals");
        }
        public async Task<IEnumerable<Referral>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Referral> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Referral> AddAsync(Referral referral)
        {
            await _collection.InsertOneAsync(referral);
            return referral;
        }
        public async Task<Referral> UpdateAsync(Referral referral)
        {
            await _collection.ReplaceOneAsync(e => e.Id == referral.Id, referral);
            return referral;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
