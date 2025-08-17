using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        private readonly AppDbContext _context;
        public LoginRequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoginRequest>> GetAllAsync() => await _context.LoginRequests.ToListAsync();
        public async Task<LoginRequest> GetByIdAsync(string id) => await _context.LoginRequests.FindAsync(id);
        public async Task<LoginRequest> AddAsync(LoginRequest loginRequest)
        {
            _context.LoginRequests.Add(loginRequest);
            await _context.SaveChangesAsync();
            return loginRequest;
        }
        public async Task<LoginRequest> UpdateAsync(LoginRequest loginRequest)
        {
            _context.LoginRequests.Update(loginRequest);
            await _context.SaveChangesAsync();
            return loginRequest;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.LoginRequests.FindAsync(id);
            if (entity == null) return false;
            _context.LoginRequests.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
