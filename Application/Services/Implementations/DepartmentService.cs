using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IDepartmentMongoRepository _mongoRepo;
        public DepartmentService(IDepartmentRepository repository, IDepartmentMongoRepository mongoRepo)
        {
            _repository = repository;
            _mongoRepo = mongoRepo;
        }
        public async Task<IEnumerable<Department>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Department?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Department entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Department entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Department>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Department> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Department> AddMongoAsync(Department entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Department> UpdateMongoAsync(Department entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
