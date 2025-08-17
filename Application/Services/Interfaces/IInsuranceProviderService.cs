using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IInsuranceProviderService
    {
        Task<IEnumerable<InsuranceProvider>> GetAllAsync();
        Task<InsuranceProvider?> GetByIdAsync(int id);
        Task AddAsync(InsuranceProvider entity);
        Task UpdateAsync(InsuranceProvider entity);
        Task DeleteAsync(int id);
        // MongoDB/model-based methods
        Task<IEnumerable<InsuranceProvider>> GetAllMongoAsync();
        Task<InsuranceProvider> GetByIdMongoAsync(int id);
        Task<InsuranceProvider> AddMongoAsync(InsuranceProvider entity);
        Task<InsuranceProvider> UpdateMongoAsync(InsuranceProvider entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
