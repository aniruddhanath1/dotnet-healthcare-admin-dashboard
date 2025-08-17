using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using dotnet_admin_dashboard.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CareGiverController : ControllerBase
    {
        private readonly ICareGiverService _service;
        public CareGiverController(ICareGiverService service)
        {
            _service = service;
        }

        // DTO-based endpoints (existing)
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());

        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] CareGiverDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }

        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] CareGiverDto dto)
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
        public async Task<ActionResult<IEnumerable<CareGiver>>> GetAll() => Ok(await _service.GetAllMongoAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CareGiver>> GetById(int id)
        {
            var result = await _service.GetByIdMongoAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CareGiver>> Add(CareGiver careGiver)
        {
            var result = await _service.AddMongoAsync(careGiver);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CareGiver>> Update(int id, CareGiver careGiver)
        {
            if (id != careGiver.Id) return BadRequest();
            var result = await _service.UpdateMongoAsync(careGiver);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteMongoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
