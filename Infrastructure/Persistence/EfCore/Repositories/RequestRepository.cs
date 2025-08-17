using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;
        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Request>> GetAllAsync() => await _context.Requests.ToListAsync();
        public async Task<Request> GetByIdAsync(string requestId) => await _context.Requests.FindAsync(requestId);
        public async Task<Request> AddAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<Request> UpdateAsync(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<bool> DeleteAsync(string requestId)
        {
            var entity = await _context.Requests.FindAsync(requestId);
            if (entity == null) return false;
            _context.Requests.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
