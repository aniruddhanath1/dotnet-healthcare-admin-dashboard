using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly AppDbContext _context;
        public MedicalRecordRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedicalRecord>> GetAllAsync() => await _context.MedicalRecords.ToListAsync();
        public async Task<MedicalRecord> GetByIdAsync(int id) => await _context.MedicalRecords.FindAsync(id);
        public async Task<MedicalRecord> AddAsync(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }
        public async Task<MedicalRecord> UpdateAsync(MedicalRecord record)
        {
            _context.MedicalRecords.Update(record);
            await _context.SaveChangesAsync();
            return record;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.MedicalRecords.FindAsync(id);
            if (entity == null) return false;
            _context.MedicalRecords.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
