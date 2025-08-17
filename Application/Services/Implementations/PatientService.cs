using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;
        private readonly IPatientMongoRepository _mongoRepo;
        public PatientService(IPatientRepository repo, IPatientMongoRepository mongoRepo) { _repo = repo; _mongoRepo = mongoRepo; }
        public async Task<IEnumerable<Patient>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Patient?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Patient entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(Patient entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        // DTO-based methods
        public async Task<IEnumerable<PatientDto>> GetAllAsync() => (await _repo.GetAllAsync()).Select(Map).ToList();
        public async Task<PatientDto> GetByIdAsync(int id) => Map(await _repo.GetByIdAsync(id));
        public async Task AddAsync(PatientDto dto) => await _repo.AddAsync(Map(dto));
        public async Task UpdateAsync(PatientDto dto) => await _repo.UpdateAsync(Map(dto));
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
        // MongoDB/model-based methods
        public async Task<IEnumerable<Patient>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<Patient> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<Patient> AddMongoAsync(Patient entity) => await _mongoRepo.AddAsync(entity);
        public async Task<Patient> UpdateMongoAsync(Patient entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
        private static PatientDto Map(Patient p) => p == null ? null : new PatientDto { Id = p.Id, Name = p.Name, DateOfBirth = p.DateOfBirth, Gender = p.Gender, MedicalRecordNumber = p.MedicalRecordNumber };
        private static Patient Map(PatientDto d) => d == null ? null : new Patient { Id = d.Id, Name = d.Name, DateOfBirth = d.DateOfBirth, Gender = d.Gender, MedicalRecordNumber = d.MedicalRecordNumber };
    }
}
