using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class SurgeryService : ISurgeryService
    {
        private readonly ISurgeryRepository _repository;
        public SurgeryService(ISurgeryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Surgery>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Surgery?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Surgery entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Surgery entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<Surgery>> GetAllMongoAsync() => await _repository.GetAllMongoAsync();
        public async Task<Surgery?> GetByIdMongoAsync(string id) => await _repository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(Surgery entity) => await _repository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(Surgery entity) => await _repository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _repository.DeleteMongoAsync(id);
    }
}
