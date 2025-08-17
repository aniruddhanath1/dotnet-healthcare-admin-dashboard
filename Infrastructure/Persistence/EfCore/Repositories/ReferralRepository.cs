using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly AppDbContext _context;
        public ReferralRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Referral>> GetAllAsync() => await _context.Referrals.ToListAsync();
        public async Task<Referral> GetByIdAsync(int id) => await _context.Referrals.FindAsync(id);
        public async Task<Referral> AddAsync(Referral referral)
        {
            _context.Referrals.Add(referral);
            await _context.SaveChangesAsync();
            return referral;
        }
        public async Task<Referral> UpdateAsync(Referral referral)
        {
            _context.Referrals.Update(referral);
            await _context.SaveChangesAsync();
            return referral;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Referrals.FindAsync(id);
            if (entity == null) return false;
            _context.Referrals.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
