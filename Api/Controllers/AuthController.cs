using Microsoft.AspNetCore.Mvc;
using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        // DTO-based endpoints
        [HttpPost("dto/login")]
        public async Task<IActionResult> LoginDto([FromBody] LoginRequestDto dto)
        {
            var result = await _service.LoginAsync(dto);
            if (!result.Success) return Unauthorized(result.Message);
            return Ok(result);
        }

        // Model-based (MongoDB) endpoints
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllMongoAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdMongoAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuthResult entity)
        {
            var result = await _service.AddMongoAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AuthResult entity)
        {
            if (id != entity.Id) return BadRequest();
            var result = await _service.UpdateMongoAsync(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteMongoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
