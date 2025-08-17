using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class BedRepository : IBedRepository
    {
        private readonly AppDbContext _context;
        public BedRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Bed>> GetAllAsync() => await _context.Beds.ToListAsync();
        public async Task<Bed> GetByIdAsync(int id) => await _context.Beds.FindAsync(id);
        public async Task<Bed> AddAsync(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();
            return bed;
        }
        public async Task<Bed> UpdateAsync(Bed bed)
        {
            _context.Beds.Update(bed);
            await _context.SaveChangesAsync();
            return bed;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Beds.FindAsync(id);
            if (entity == null) return false;
            _context.Beds.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
