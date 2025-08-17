using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAllAsync();
        Task<Medication> GetByIdAsync(int id);
        Task<Medication> AddAsync(Medication medication);
        Task<Medication> UpdateAsync(Medication medication);
        Task<bool> DeleteAsync(int id);
    }
}
