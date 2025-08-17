using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly AppDbContext _context;
        public SupplyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supply>> GetAllAsync() => await _context.Supplies.ToListAsync();
        public async Task<Supply> GetByIdAsync(int id) => await _context.Supplies.FindAsync(id);
        public async Task<Supply> AddAsync(Supply supply)
        {
            _context.Supplies.Add(supply);
            await _context.SaveChangesAsync();
            return supply;
        }
        public async Task<Supply> UpdateAsync(Supply supply)
        {
            _context.Supplies.Update(supply);
            await _context.SaveChangesAsync();
            return supply;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Supplies.FindAsync(id);
            if (entity == null) return false;
            _context.Supplies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
