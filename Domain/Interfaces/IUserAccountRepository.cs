using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>> GetAllAsync();
        Task<UserAccount> GetByIdAsync(int id);
        Task<UserAccount> AddAsync(UserAccount userAccount);
        Task<UserAccount> UpdateAsync(UserAccount userAccount);
        Task<bool> DeleteAsync(int id);
    }
}
