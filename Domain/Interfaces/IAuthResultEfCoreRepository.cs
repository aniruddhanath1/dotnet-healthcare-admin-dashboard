using dotnet_admin_dashboard.Domain.Entities;

namespace DotNetAdminPanel.Domain.Interfaces
{
    public interface IAuthResultEfCoreRepository
    {
        // EF Core specific repository interface for AuthResult
        Task<IEnumerable<AuthResult>> GetAllAsync();

        Task<AuthResult> GetByIdAsync(Guid id);

        Task<AuthResult> AddAsync(AuthResult authResult);

        Task<AuthResult> UpdateAsync(AuthResult authResult);
        
        Task<bool> DeleteAsync(Guid id);
    }
}
