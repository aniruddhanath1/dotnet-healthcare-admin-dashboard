using Microsoft.EntityFrameworkCore;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AuthResult> AuthResults { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<CareGiver> CareGivers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DischargeSummary> DischargeSummaries { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<ErrorResponse> ErrorResponses { get; set; }
        public DbSet<InsuranceProvider> InsuranceProviders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<LoginRequest> LoginRequests { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<SuccessResponse> SuccessResponses { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Visit> Visits { get; set; }


        // Add other DbSets here
    }
}
