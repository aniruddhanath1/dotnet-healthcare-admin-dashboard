using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IShiftRepository
    {
        Task<IEnumerable<Shift>> GetAllAsync();
        Task<Shift> GetByIdAsync(int id);
        Task<Shift> AddAsync(Shift shift);
        Task<Shift> UpdateAsync(Shift shift);
        Task<bool> DeleteAsync(int id);
    }
}
