using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext _context;
        public EquipmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Equipment>> GetAllAsync() => await _context.Equipments.ToListAsync();
        public async Task<Equipment> GetByIdAsync(int id) => await _context.Equipments.FindAsync(id);
        public async Task<Equipment> AddAsync(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }
        public async Task<Equipment> UpdateAsync(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Equipments.FindAsync(id);
            if (entity == null) return false;
            _context.Equipments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
