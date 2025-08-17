using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IErrorResponseMongoRepository
    {
        Task InsertAsync(ErrorResponse entity);
        Task<List<ErrorResponse>> GetAllAsync();
        Task<ErrorResponse?> GetByIdAsync(string id);
        Task UpdateAsync(string id, ErrorResponse entity);
        Task DeleteAsync(string id);
    }
}
