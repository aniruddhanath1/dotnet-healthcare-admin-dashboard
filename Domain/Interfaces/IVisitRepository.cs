using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAllAsync();
        Task<Visit> GetByIdAsync(int id);
        Task<Visit> AddAsync(Visit visit);
        Task<Visit> UpdateAsync(Visit visit);
        Task<bool> DeleteAsync(int id);
    }
}
