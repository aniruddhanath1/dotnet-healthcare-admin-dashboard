using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class AmbulanceService : IAmbulanceService
    {
        private readonly IAmbulanceAdoRepository _adoRepo;
        private readonly IAmbulanceEfCoreRepository _efCoreRepo;
        private readonly IAmbulanceMongoRepository _mongoRepo;
        public AmbulanceService(IAmbulanceAdoRepository adoRepository, IAmbulanceEfCoreRepository efCoreRepository, IAmbulanceMongoRepository mongoRepository)
        {
            _adoRepo = adoRepository;
            _efCoreRepo = efCoreRepository;
            _mongoRepo = mongoRepository;
        }

        // ADO.NET methods
        public async Task<IEnumerable<Ambulance>> GetAllAsync() => await _adoRepo.GetAllAsync();
        public async Task<Ambulance> GetByIdAsync(string id) => await _adoRepo.GetByIdAsync(id);
        public async Task<Ambulance> AddAsync(AmbulanceDto entity) => await _adoRepo.AddAsync(entity);
        public async Task<Ambulance> UpdateAsync(AmbulanceDto entity) => await _adoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteAsync(string id) => await _adoRepo.DeleteAsync(id);

        // EF Core methods
        public async Task<IEnumerable<Ambulance>> GetAllAsync() => await _efCoreRepo.GetAllAsync();
        public async Task<Ambulance?> GetByIdAsync(string id) => await _efCoreRepo.GetByIdAsync(id);
        public async Task AddAsync(Ambulance entity) => await _efCoreRepo.AddAsync(entity);
        public async Task UpdateAsync(Ambulance entity) => await _efCoreRepo.UpdateAsync(entity);
        public async Task DeleteAsync(string id) => await _efCoreRepo.DeleteAsync(id);

        // MongoDB/model-based methods
        public async Task<IEnumerable<Ambulance>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Ambulance> GetByIdMongoAsync(string id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Ambulance> AddMongoAsync(Ambulance entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Ambulance> UpdateMongoAsync(Ambulance entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(string id) => await _mongoRepo.DeleteAsync(id);
    }
}
