using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ILabTestRepository
    {
        Task<IEnumerable<LabTest>> GetAllAsync();
        Task<LabTest> GetByIdAsync(int id);
        Task<LabTest> AddAsync(LabTest test);
        Task<LabTest> UpdateAsync(LabTest test);
        Task<bool> DeleteAsync(int id);
    }
}
