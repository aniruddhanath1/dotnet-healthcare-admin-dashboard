using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class NurseService : INurseService
    {
        private readonly INurseRepository _repo;
        private readonly INurseMongoRepository _mongoRepo;
        public NurseService(INurseRepository repo, INurseMongoRepository mongoRepo) { _repo = repo; _mongoRepo = mongoRepo; }
        public async Task<IEnumerable<Nurse>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Nurse?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Nurse entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Nurse entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // DTO-based methods
        public async Task<IEnumerable<NurseDto>> GetAllAsync() => (await _repo.GetAllAsync()).Select(Map).ToList();
        public async Task<NurseDto> GetByIdAsync(int id) => Map(await _repo.GetByIdAsync(id));
        public async Task AddAsync(NurseDto dto) => await _repo.AddAsync(Map(dto));
        public async Task UpdateAsync(NurseDto dto) => await _repo.UpdateAsync(Map(dto));
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Nurse>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Nurse> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Nurse> AddMongoAsync(Nurse entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Nurse> UpdateMongoAsync(Nurse entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
        private static NurseDto Map(Nurse n) => n == null ? null : new NurseDto { Id = n.Id, Name = n.Name, LicenseNumber = n.LicenseNumber, Department = n.Department };
        private static Nurse Map(NurseDto d) => d == null ? null : new Nurse { Id = d.Id, Name = d.Name, LicenseNumber = d.LicenseNumber, Department = d.Department };
    }
}
