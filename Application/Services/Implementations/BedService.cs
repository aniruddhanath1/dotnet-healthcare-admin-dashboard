using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class BedService : IBedService
    {
        private readonly IBedRepository _repository;
        private readonly IBedMongoRepository _mongoRepo;
        public BedService(IBedRepository repository, IBedMongoRepository mongoRepo)
        {
            _repository = repository;
            _mongoRepo = mongoRepo;
        }
        public async Task<IEnumerable<Bed>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Bed?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Bed entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Bed entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Bed>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Bed> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Bed> AddMongoAsync(Bed entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Bed> UpdateMongoAsync(Bed entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
