using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _repository;
        public SupplyService(ISupplyRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Supply>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Supply> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Supply> AddAsync(Supply supply) => await _repository.AddAsync(supply);
        public async Task<Supply> UpdateAsync(Supply supply) => await _repository.UpdateAsync(supply);
        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<Supply>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<Supply?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(Supply entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(Supply entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
