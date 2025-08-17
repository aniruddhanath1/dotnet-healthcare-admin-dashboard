using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Application.DTOs;

namespace dotnet_admin_dashboard.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDto> LoginAsync(LoginRequestDto dto);
        // MongoDB/model-based methods
        Task<IEnumerable<AuthResult>> GetAllMongoAsync();
        Task<AuthResult> GetByIdMongoAsync(int id);
        Task<AuthResult> AddMongoAsync(AuthResult entity);
        Task<AuthResult> UpdateMongoAsync(AuthResult entity);
        Task<bool> DeleteMongoAsync(int id);
    }
}
