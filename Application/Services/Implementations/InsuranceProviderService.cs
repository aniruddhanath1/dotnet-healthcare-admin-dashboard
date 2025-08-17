using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class InsuranceProviderService : IInsuranceProviderService
    {
        private readonly IInsuranceProviderRepository _repository;
        private readonly IInsuranceProviderMongoRepository _mongoRepo;
        public InsuranceProviderService(IInsuranceProviderRepository repository, IInsuranceProviderMongoRepository mongoRepo)
        {
            _repository = repository;
            _mongoRepo = mongoRepo;
        }
        public async Task<IEnumerable<InsuranceProvider>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<InsuranceProvider?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(InsuranceProvider entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(InsuranceProvider entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<InsuranceProvider>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<InsuranceProvider> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<InsuranceProvider> AddMongoAsync(InsuranceProvider entity) => await _mongoRepo.AddAsync(entity);
        public async Task<InsuranceProvider> UpdateMongoAsync(InsuranceProvider entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
