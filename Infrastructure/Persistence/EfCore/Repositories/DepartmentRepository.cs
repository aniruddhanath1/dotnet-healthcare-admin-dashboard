using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllAsync() => await _context.Departments.ToListAsync();
        public async Task<Department> GetByIdAsync(int id) => await _context.Departments.FindAsync(id);
        public async Task<Department> AddAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }
        public async Task<Department> UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Departments.FindAsync(id);
            if (entity == null) return false;
            _context.Departments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
