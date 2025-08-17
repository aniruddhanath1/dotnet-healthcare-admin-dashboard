using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context) { _context = context; }
        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _context.Doctors.ToListAsync();
        public async Task<Doctor> GetByIdAsync(int id) => await _context.Doctors.FindAsync(id);
        public async Task AddAsync(Doctor doctor) { _context.Doctors.Add(doctor); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Doctor doctor) { _context.Doctors.Update(doctor); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var entity = await _context.Doctors.FindAsync(id); if (entity != null) { _context.Doctors.Remove(entity); await _context.SaveChangesAsync(); } }
    }
}
