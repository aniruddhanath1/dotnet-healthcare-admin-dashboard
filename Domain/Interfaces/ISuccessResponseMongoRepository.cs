using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ISuccessResponseMongoRepository
    {
        Task InsertAsync(SuccessResponse entity);
        Task<List<SuccessResponse>> GetAllAsync();
        Task<SuccessResponse?> GetByIdAsync(string id);
        Task UpdateAsync(string id, SuccessResponse entity);
        Task DeleteAsync(string id);
    }
}
