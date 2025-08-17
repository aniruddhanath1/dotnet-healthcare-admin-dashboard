using dotnet_admin_dashboard.Domain.Entities;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IErrorResponseRepository
    {
        Task<IEnumerable<ErrorResponse>> GetAllAsync();
        Task<ErrorResponse> GetByIdAsync(int id);
        Task<ErrorResponse> AddAsync(ErrorResponse errorResponse);
        Task<ErrorResponse> UpdateAsync(ErrorResponse errorResponse);
        Task<bool> DeleteAsync(int id);
    }
}
