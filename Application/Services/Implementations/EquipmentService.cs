using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentService(IEquipmentRepository repository, EquipmentMongoRepository mongoRepo)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Equipment>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Equipment> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Equipment> AddAsync(Equipment equipment) => await _repository.AddAsync(equipment);
        public async Task<Equipment> UpdateAsync(Equipment equipment) => await _repository.UpdateAsync(equipment);
        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Equipment>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Equipment> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Equipment> AddMongoAsync(Equipment entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Equipment> UpdateMongoAsync(Equipment entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
