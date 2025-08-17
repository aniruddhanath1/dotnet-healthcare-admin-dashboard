using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using dotnet_admin_dashboard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service)
        {
            _service = service;
        }
        // DTO-based endpoints
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());
        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] PatientDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] PatientDto dto)
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
        public async Task<IActionResult> Add([FromBody] Patient patient)
        {
            var result = await _service.AddMongoAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id) return BadRequest();
            var result = await _service.UpdateMongoAsync(patient);
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
