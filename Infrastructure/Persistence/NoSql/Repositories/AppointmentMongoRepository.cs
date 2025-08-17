using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class AppointmentMongoRepository : IAppointmentRepository
    {
        private readonly IMongoCollection<Appointment> _collection;
        public AppointmentMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Appointment>("Appointments");
        }
        public async Task<IEnumerable<Appointment>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<Appointment> GetByIdAsync(int id) => await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            await _collection.InsertOneAsync(appointment);
            return appointment;
        }
        public async Task<Appointment> UpdateAsync(Appointment appointment)
        {
            await _collection.ReplaceOneAsync(e => e.Id == appointment.Id, appointment);
            return appointment;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(e => e.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
