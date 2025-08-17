using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly AppDbContext _context;
        public MedicationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Medication>> GetAllAsync() => await _context.Medications.ToListAsync();
        public async Task<Medication> GetByIdAsync(int id) => await _context.Medications.FindAsync(id);
        public async Task<Medication> AddAsync(Medication medication)
        {
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();
            return medication;
        }
        public async Task<Medication> UpdateAsync(Medication medication)
        {
            _context.Medications.Update(medication);
            await _context.SaveChangesAsync();
            return medication;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Medications.FindAsync(id);
            if (entity == null) return false;
            _context.Medications.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
