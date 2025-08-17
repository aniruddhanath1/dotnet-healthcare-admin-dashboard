using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;
        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Invoice>> GetAllAsync() => await _context.Invoices.ToListAsync();
        public async Task<Invoice> GetByIdAsync(int id) => await _context.Invoices.FindAsync(id);
        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Invoices.FindAsync(id);
            if (entity == null) return false;
            _context.Invoices.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
