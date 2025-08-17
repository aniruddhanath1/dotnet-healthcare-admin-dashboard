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
    public class SupplyController : ControllerBase
    {
        private readonly ISupplyService _service;
        public SupplyController(ISupplyService service)
        {
            _service = service;
        }
        // DTO-based endpoints
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());
        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] SupplyDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] SupplyDto dto)
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
        public async Task<ActionResult<IEnumerable<Supply>>> GetAll() => Ok(await _service.GetAllMongoAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetById(string id)
        {
            var item = await _service.GetByIdMongoAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<Supply>> Add([FromBody] Supply supply)
        {
            await _service.AddMongoAsync(supply);
            return CreatedAtAction(nameof(GetById), new { id = supply.Id }, supply);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Supply>> Update(int id, [FromBody] Supply supply)
        {
            if (id != supply.Id) return BadRequest();
            await _service.UpdateMongoAsync(supply);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
