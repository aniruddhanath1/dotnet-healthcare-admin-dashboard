using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IPatientService
    {
        // DTO-based methods
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task AddAsync(PatientDto dto);
        Task UpdateAsync(PatientDto dto);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Patient>> GetAllMongoAsync();
        Task<Patient> GetByIdMongoAsync(int id);
        Task<Patient> AddMongoAsync(Patient entity);
        Task<Patient> UpdateMongoAsync(Patient entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}

