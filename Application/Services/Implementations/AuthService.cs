using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthResultMongoRepository _mongoRepo;
        public AuthService(IUserRepository userRepo, IAuthResultMongoRepository mongoRepo) { _userRepo = userRepo; _mongoRepo = mongoRepo; }
        public async Task<AuthResultDto> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null || user.PasswordHash != dto.Password) // Replace with real hash check
            {
                return new AuthResultDto { Success = false, Message = "Invalid credentials" };
            }
            // Generate token (placeholder)
            return new AuthResultDto { Success = true, Message = "Login successful", Token = "token-placeholder" };
        }
        // MongoDB/model-based methods
        public async Task<IEnumerable<AuthResult>> GetAllMongoAsync() => await _mongoRepo.GetAllAsync();
        public async Task<AuthResult> GetByIdMongoAsync(int id) => await _mongoRepo.GetByIdAsync(id);
        public async Task<AuthResult> AddMongoAsync(AuthResult entity) => await _mongoRepo.AddAsync(entity);
        public async Task<AuthResult> UpdateMongoAsync(AuthResult entity) => await _mongoRepo.UpdateAsync(entity);
        public async Task<bool> DeleteMongoAsync(int id) => await _mongoRepo.DeleteAsync(id);
    }
}
