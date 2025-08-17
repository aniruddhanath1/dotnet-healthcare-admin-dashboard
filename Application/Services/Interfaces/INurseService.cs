using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface INurseService
    {
        // DTO-based methods
        Task<IEnumerable<NurseDto>> GetAllAsync();
        Task<NurseDto> GetByIdAsync(int id);
        Task AddAsync(NurseDto dto);
        Task UpdateAsync(NurseDto dto);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Nurse>> GetAllMongoAsync();
        Task<Nurse> GetByIdMongoAsync(int id);
        Task<Nurse> AddMongoAsync(Nurse entity);
        Task<Nurse> UpdateMongoAsync(Nurse entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
