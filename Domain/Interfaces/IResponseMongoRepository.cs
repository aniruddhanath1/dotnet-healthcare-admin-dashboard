using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IResponseMongoRepository
    {
        Task InsertAsync(Response entity);
        Task<List<Response>> GetAllAsync();
        Task<Response?> GetByIdAsync(string id);
        Task UpdateAsync(string id, Response entity);
        Task DeleteAsync(string id);
    }
}
