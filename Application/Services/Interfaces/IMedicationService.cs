using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IMedicationService
    {
        Task<IEnumerable<Medication>> GetAllAsync();
        Task<Medication?> GetByIdAsync(int id);
        Task AddAsync(Medication entity);
        Task UpdateAsync(Medication entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<Medication>> GetAllMongoAsync();
        Task<Medication?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(Medication entity);
        Task UpdateMongoAsync(Medication entity);
        Task DeleteMongoAsync(string id);
    }
}
