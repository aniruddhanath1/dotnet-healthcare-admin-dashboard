using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        private readonly IDoctorMongoRepository _mongoRepo;
        public DoctorService(IDoctorRepository repo, IDoctorMongoRepository mongoRepo) { _repo = repo; _mongoRepo = mongoRepo; }
        // DTO-based methods
        public async Task<IEnumerable<DoctorDto>> GetAllAsync() => (await _repo.GetAllAsync()).Select(Map).ToList();
        public async Task<DoctorDto> GetByIdAsync(int id) => Map(await _repo.GetByIdAsync(id));
        public async Task AddAsync(DoctorDto dto) => await _repo.AddAsync(Map(dto));
        public async Task UpdateAsync(DoctorDto dto) => await _repo.UpdateAsync(Map(dto));
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Doctor>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Doctor> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Doctor> AddMongoAsync(Doctor entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Doctor> UpdateMongoAsync(Doctor entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
        private static DoctorDto Map(Doctor d) => d == null ? null : new DoctorDto { Id = d.Id, Name = d.Name, Specialty = d.Specialty, LicenseNumber = d.LicenseNumber };
        private static Doctor Map(DoctorDto d) => d == null ? null : new Doctor { Id = d.Id, Name = d.Name, Specialty = d.Specialty, LicenseNumber = d.LicenseNumber };
    }
}
