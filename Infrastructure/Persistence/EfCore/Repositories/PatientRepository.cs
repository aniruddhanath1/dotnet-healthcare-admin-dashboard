using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;
        public PatientRepository(AppDbContext context) { _context = context; }
        public async Task<IEnumerable<Patient>> GetAllAsync() => await _context.Patients.ToListAsync();
        public async Task<Patient> GetByIdAsync(int id) => await _context.Patients.FindAsync(id);
        public async Task AddAsync(Patient patient) { _context.Patients.Add(patient); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Patient patient) { _context.Patients.Update(patient); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var entity = await _context.Patients.FindAsync(id); if (entity != null) { _context.Patients.Remove(entity); await _context.SaveChangesAsync(); } }
    }
}
