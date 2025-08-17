using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<Request> GetByIdAsync(string requestId);
        Task<Request> AddAsync(Request request);
        Task<Request> UpdateAsync(Request request);
        Task<bool> DeleteAsync(string requestId);
    }
}
