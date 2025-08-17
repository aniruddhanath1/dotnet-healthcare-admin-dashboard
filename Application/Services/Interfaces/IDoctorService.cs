using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Application.DTOs;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IDoctorService
    {
        // DTO-based methods
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<DoctorDto> GetByIdAsync(int id);
        Task AddAsync(DoctorDto dto);
        Task UpdateAsync(DoctorDto dto);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Doctor>> GetAllMongoAsync();
        Task<Doctor> GetByIdMongoAsync(int id);
        Task<Doctor> AddMongoAsync(Doctor entity);
        Task<Doctor> UpdateMongoAsync(Doctor entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
