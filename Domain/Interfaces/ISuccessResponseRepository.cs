using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface ISuccessResponseRepository
    {
        Task<IEnumerable<SuccessResponse>> GetAllAsync();
        Task<SuccessResponse> GetByIdAsync(int id);
        Task<SuccessResponse> AddAsync(SuccessResponse successResponse);
        Task<SuccessResponse> UpdateAsync(SuccessResponse successResponse);
        Task<bool> DeleteAsync(int id);
    }
}
