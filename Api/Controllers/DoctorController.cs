using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using dotnet_admin_dashboard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        // DTO-based endpoints
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());

        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] DoctorDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }

        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] DoctorDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("dto/{id}")]
        public async Task<IActionResult> DeleteDto(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // MongoDB/model-based endpoints
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
        public async Task<IActionResult> Add([FromBody] Doctor doctor)
        {
            var result = await _service.AddMongoAsync(doctor);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id) return BadRequest();
            var result = await _service.UpdateMongoAsync(doctor);
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
