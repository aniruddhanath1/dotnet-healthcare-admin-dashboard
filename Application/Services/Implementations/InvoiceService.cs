using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Invoice>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Invoice?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Invoice entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Invoice entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<Invoice>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<Invoice?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(Invoice entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(Invoice entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
