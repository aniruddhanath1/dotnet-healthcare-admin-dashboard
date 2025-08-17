using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task AddAsync(Department entity);
        Task UpdateAsync(Department entity);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<Department>> GetAllMongoAsync();
        Task<Department> GetByIdMongoAsync(int id);
        Task<Department> AddMongoAsync(Department entity);
        Task<Department> UpdateMongoAsync(Department entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
