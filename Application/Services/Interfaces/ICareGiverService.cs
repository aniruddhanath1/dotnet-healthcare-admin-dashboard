using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Application.DTOs;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface ICareGiverService
    {
        // DTO-based methods
        Task<IEnumerable<CareGiverDto>> GetAllAsync();
        Task<CareGiverDto> GetByIdAsync(int id);
        Task AddAsync(CareGiverDto dto);
        Task UpdateAsync(CareGiverDto dto);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<CareGiver>> GetAllMongoAsync();
        Task<CareGiver> GetByIdMongoAsync(int id);
        Task<CareGiver> AddMongoAsync(CareGiver entity);
        Task<CareGiver> UpdateMongoAsync(CareGiver entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
