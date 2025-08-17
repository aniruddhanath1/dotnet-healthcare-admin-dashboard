using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IInsuranceProviderRepository
    {
        Task<IEnumerable<InsuranceProvider>> GetAllAsync();
        Task<InsuranceProvider> GetByIdAsync(int id);
        Task<InsuranceProvider> AddAsync(InsuranceProvider provider);
        Task<InsuranceProvider> UpdateAsync(InsuranceProvider provider);
        Task<bool> DeleteAsync(int id);
    }
}
