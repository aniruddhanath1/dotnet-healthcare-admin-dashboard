using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetAllAsync() => await _context.Rooms.ToListAsync();
        public async Task<Room> GetByIdAsync(int id) => await _context.Rooms.FindAsync(id);
        public async Task<Room> AddAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<Room> UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Rooms.FindAsync(id);
            if (entity == null) return false;
            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
