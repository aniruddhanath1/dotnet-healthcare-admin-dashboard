using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<IEnumerable<UserAccount>> GetAllAsync() => await _userAccountRepository.GetAllAsync();

        public async Task<UserAccount> GetByIdAsync(int id) => await _userAccountRepository.GetByIdAsync(id);

        public async Task<UserAccount> AddAsync(UserAccount userAccount) => await _userAccountRepository.AddAsync(userAccount);

        public async Task<UserAccount> UpdateAsync(UserAccount userAccount) => await _userAccountRepository.UpdateAsync(userAccount);

        public async Task<bool> DeleteAsync(int id) => await _userAccountRepository.DeleteAsync(id);

        // MongoDB/NoSQL CRUD methods
        public async Task<IEnumerable<UserAccount>> GetAllMongoAsync() => await _userAccountRepository.GetAllMongoAsync();
        public async Task<UserAccount?> GetByIdMongoAsync(string id) => await _userAccountRepository.GetByIdMongoAsync(id);
        public async Task AddMongoAsync(UserAccount entity) => await _userAccountRepository.AddMongoAsync(entity);
        public async Task UpdateMongoAsync(UserAccount entity) => await _userAccountRepository.UpdateMongoAsync(entity);
        public async Task DeleteMongoAsync(string id) => await _userAccountRepository.DeleteMongoAsync(id);
    }
}
