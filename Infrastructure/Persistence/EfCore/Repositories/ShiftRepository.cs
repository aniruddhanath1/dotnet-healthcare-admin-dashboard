using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _context;
        public ShiftRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Shift>> GetAllAsync() => await _context.Shifts.ToListAsync();
        public async Task<Shift> GetByIdAsync(int id) => await _context.Shifts.FindAsync(id);
        public async Task<Shift> AddAsync(Shift shift)
        {
            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();
            return shift;
        }
        public async Task<Shift> UpdateAsync(Shift shift)
        {
            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();
            return shift;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Shifts.FindAsync(id);
            if (entity == null) return false;
            _context.Shifts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
