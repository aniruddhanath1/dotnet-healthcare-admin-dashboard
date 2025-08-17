using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class InvoiceMongoRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> _collection;
        public InvoiceMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Invoice>("Invoices");
        }
        public async Task<IEnumerable<Invoice>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Invoice> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            await _collection.InsertOneAsync(invoice);
            return invoice;
        }
        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {
            await _collection.ReplaceOneAsync(e => e.Id == invoice.Id, invoice);
            return invoice;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
