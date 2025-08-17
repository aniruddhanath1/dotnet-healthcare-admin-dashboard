using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class DischargeSummaryService : IDischargeSummaryService
    {
        private readonly IDischargeSummaryRepository _repository;
        private readonly IDischargeSummaryMongoRepository _mongoRepo;
        public DischargeSummaryService(IDischargeSummaryRepository repository, IDischargeSummaryMongoRepository mongoRepo)
        {
            _repository = repository;
            _mongoRepo = mongoRepo;
        }
        public async Task<IEnumerable<DischargeSummary>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<DischargeSummary?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(DischargeSummary entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(DischargeSummary entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<DischargeSummary>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<DischargeSummary> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<DischargeSummary> AddMongoAsync(DischargeSummary entity) => await _mongoRepo.AddAsync(entity);
        public async Task<DischargeSummary> UpdateMongoAsync(DischargeSummary entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
