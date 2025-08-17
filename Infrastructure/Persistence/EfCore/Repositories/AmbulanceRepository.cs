using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using DotNetAdminPanel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class AmbulanceRepository : IAmbulanceEfCoreRepository
    {
        private readonly AppDbContext _context;
        public AmbulanceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ambulance>> GetAllAsync() => await _context.Ambulances.ToListAsync();
        public async Task<Ambulance> GetByIdAsync(string id) => await _context.Ambulances.FindAsync(id);
        public async Task<Ambulance> AddAsync(Ambulance ambulance)
        {
            _context.Ambulances.Add(ambulance);
            await _context.SaveChangesAsync();
            return ambulance;
        }
        public async Task<Ambulance> UpdateAsync(Ambulance ambulance)
        {
            _context.Ambulances.Update(ambulance);
            await _context.SaveChangesAsync();
            return ambulance;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.Ambulances.FindAsync(id);
            if (entity == null) return false;
            _context.Ambulances.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
