using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IRequestMongoRepository
    {
        Task InsertAsync(Request entity);
        Task<List<Request>> GetAllAsync();
        Task<Request?> GetByIdAsync(string id);
        Task UpdateAsync(string id, Request entity);
        Task DeleteAsync(string id);
    }
}
