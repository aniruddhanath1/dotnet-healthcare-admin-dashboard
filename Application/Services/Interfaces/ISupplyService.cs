using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface ISupplyService
    {
        // SQL CRUD methods
        Task<IEnumerable<Supply>> GetAllAsync();
        Task<Supply> GetByIdAsync(int id);
        Task<Supply> AddAsync(SupplyDto supply);
        Task<Supply> UpdateAsync(SupplyDto supply);
        Task<bool> DeleteAsync(int id);

        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Supply>> GetAllMongoAsync();
        Task<Supply?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Supply entity);
        Task UpdateMongoAsync(Supply entity);
        Task DeleteMongoAsync(string id);
    }
}
