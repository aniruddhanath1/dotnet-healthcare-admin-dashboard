using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IReferralRepository
    {
        Task<IEnumerable<Referral>> GetAllAsync();
        Task<Referral> GetByIdAsync(int id);
        Task<Referral> AddAsync(Referral referral);
        Task<Referral> UpdateAsync(Referral referral);
        Task<bool> DeleteAsync(int id);
    }
}
