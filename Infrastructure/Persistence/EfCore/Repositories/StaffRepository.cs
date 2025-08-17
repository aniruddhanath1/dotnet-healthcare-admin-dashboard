using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;
        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAllAsync() => await _context.Staffs.ToListAsync();
        public async Task<Staff> GetByIdAsync(int id) => await _context.Staffs.FindAsync(id);
        public async Task<Staff> AddAsync(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }
        public async Task<Staff> UpdateAsync(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
            return staff;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Staffs.FindAsync(id);
            if (entity == null) return false;
            _context.Staffs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
