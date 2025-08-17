using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class CareGiverService : ICareGiverService
    {
        private readonly ICareGiverRepository _repo;
        private readonly ICareGiverMongoRepository _mongoRepo;
        public CareGiverService(ICareGiverRepository repo, ICareGiverMongoRepository mongoRepo) { _repo = repo; _mongoRepo = mongoRepo; }
        // DTO-based methods
        public async Task<IEnumerable<CareGiverDto>> GetAllAsync() => (await _repo.GetAllAsync()).Select(Map).ToList();
        public async Task<CareGiverDto> GetByIdAsync(int id) => Map(await _repo.GetByIdAsync(id));
        public async Task AddAsync(CareGiverDto dto) => await _repo.AddAsync(Map(dto));
        public async Task UpdateAsync(CareGiverDto dto) => await _repo.UpdateAsync(Map(dto));
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<CareGiver>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<CareGiver> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<CareGiver> AddMongoAsync(CareGiver entity) => await _mongoRepo.AddAsync(entity);
        public async Task<CareGiver> UpdateMongoAsync(CareGiver entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
        private static CareGiverDto Map(CareGiver c) => c == null ? null : new CareGiverDto { Id = c.Id, Name = c.Name, Relationship = c.Relationship, ContactNumber = c.ContactNumber };
        private static CareGiver Map(CareGiverDto d) => d == null ? null : new CareGiver { Id = d.Id, Name = d.Name, Relationship = d.Relationship, ContactNumber = d.ContactNumber };
    }
}
