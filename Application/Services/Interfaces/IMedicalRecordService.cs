using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetAllAsync();
        Task<MedicalRecord?> GetByIdAsync(int id);
        Task AddAsync(MedicalRecord entity);
        Task UpdateAsync(MedicalRecord entity);
        Task DeleteAsync(int id);
        // MongoDB/NoSQL CRUD methods
        Task<IEnumerable<MedicalRecord>> GetAllMongoAsync();
        Task<MedicalRecord?> GetByIdMongoAsync(string id);
        Task AddMongoAsync(MedicalRecord entity);
        Task UpdateMongoAsync(MedicalRecord entity);
        Task DeleteMongoAsync(string id);
    }
}
