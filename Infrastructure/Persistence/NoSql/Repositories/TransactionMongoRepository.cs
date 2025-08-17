using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class TransactionMongoRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Transaction> _collection;
        public TransactionMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Transaction>("Transactions");
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Transaction> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            await _collection.InsertOneAsync(transaction);
            return transaction;
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            await _collection.ReplaceOneAsync(x => x.Id == transaction.Id, transaction);
            return transaction;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
