using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetAllAsync();
        Task<Response> GetByIdAsync(string requestId);
        Task<Response> AddAsync(Response response);
        Task<Response> UpdateAsync(Response response);
        Task<bool> DeleteAsync(string requestId);
    }
}
