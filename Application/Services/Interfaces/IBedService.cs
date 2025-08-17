using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IBedService
    {
        Task<IEnumerable<Bed>> GetAllAsync();
        Task<Bed?> GetByIdAsync(int id);
        Task AddAsync(Bed entity);
        Task UpdateAsync(Bed entity);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Bed>> GetAllMongoAsync();
        Task<Bed> GetByIdMongoAsync(int id);
        Task<Bed> AddMongoAsync(Bed entity);
        Task<Bed> UpdateMongoAsync(Bed entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
