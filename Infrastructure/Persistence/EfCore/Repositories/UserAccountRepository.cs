using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AppDbContext _context;
        public UserAccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserAccount>> GetAllAsync() => await _context.UserAccounts.ToListAsync();
        public async Task<UserAccount> GetByIdAsync(int id) => await _context.UserAccounts.FindAsync(id);
        public async Task<UserAccount> AddAsync(UserAccount userAccount)
        {
            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();
            return userAccount;
        }
        public async Task<UserAccount> UpdateAsync(UserAccount userAccount)
        {
            _context.UserAccounts.Update(userAccount);
            await _context.SaveChangesAsync();
            return userAccount;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.UserAccounts.FindAsync(id);
            if (entity == null) return false;
            _context.UserAccounts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
