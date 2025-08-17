using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class AuthResultRepository : IAuthResultRepository
    {
        private readonly AppDbContext _context;
        public AuthResultRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AuthResult>> GetAllAsync() => await _context.AuthResults.ToListAsync();
        public async Task<AuthResult> GetByIdAsync(int id) => await _context.AuthResults.FindAsync(id);
        public async Task<AuthResult> AddAsync(AuthResult authResult)
        {
            _context.AuthResults.Add(authResult);
            await _context.SaveChangesAsync();
            return authResult;
        }
        public async Task<AuthResult> UpdateAsync(AuthResult authResult)
        {
            _context.AuthResults.Update(authResult);
            await _context.SaveChangesAsync();
            return authResult;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.AuthResults.FindAsync(id);
            if (entity == null) return false;
            _context.AuthResults.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
