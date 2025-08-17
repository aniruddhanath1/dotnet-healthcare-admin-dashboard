using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using MongoDB.Driver;

namespace dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories
{
    public class DoctorMongoRepository : IDoctorRepository
    {
        private readonly IMongoCollection<Doctor> _collection;
        public DoctorMongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Doctor>("Doctors");
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Doctor> GetByIdAsync(int id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            await _collection.InsertOneAsync(doctor);
            return doctor;
        }

        public async Task<Doctor> UpdateAsync(Doctor doctor)
        {
            await _collection.ReplaceOneAsync(x => x.Id == doctor.Id, doctor);
            return doctor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
