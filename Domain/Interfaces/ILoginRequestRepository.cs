using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ILoginRequestRepository
    {
        Task<IEnumerable<LoginRequest>> GetAllAsync();
        Task<LoginRequest> GetByIdAsync(string id);
        Task<LoginRequest> AddAsync(LoginRequest loginRequest);
        Task<LoginRequest> UpdateAsync(LoginRequest loginRequest);
        Task<bool> DeleteAsync(string id);
    }
}
