using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface ILabTestService
    {
        Task<IEnumerable<LabTest>> GetAllAsync();
        Task<LabTest?> GetByIdAsync(int id);
        Task AddAsync(LabTest entity);
        Task UpdateAsync(LabTest entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<LabTest>> GetAllMongoAsync();
        Task<LabTest?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(LabTest entity);
        Task UpdateMongoAsync(LabTest entity);
        Task DeleteMongoAsync(string id);
    }
}
