using dotnet_admin_dashboard.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(int id);
        Task<Invoice> AddAsync(Invoice invoice);
        Task<Invoice> UpdateAsync(Invoice invoice);
        Task<bool> DeleteAsync(int id);
    }
}
