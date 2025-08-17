using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Application.DTOs;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;
        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }
        // DTO-based endpoints
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());
        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] EquipmentDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] EquipmentDto dto)
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
        public async Task<ActionResult<IEnumerable<Equipment>>> GetAll() => Ok(await _service.GetAllMongoAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetById(int id)
        {
            var result = await _service.GetByIdMongoAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Equipment>> Add([FromBody] Equipment equipment)
        {
            var result = await _service.AddMongoAsync(equipment);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Equipment>> Update(int id, [FromBody] Equipment equipment)
        {
            if (id != equipment.Id) return BadRequest();
            var result = await _service.UpdateMongoAsync(equipment);
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
