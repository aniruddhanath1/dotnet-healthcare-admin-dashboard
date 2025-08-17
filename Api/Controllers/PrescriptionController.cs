using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using dotnet_admin_dashboard.Application.DTOs;
using dotnet_admin_dashboard.Domain.Entities;

namespace dotnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;
        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }
        // DTO-based endpoints
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());
        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] PrescriptionDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] PrescriptionDto dto)
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
        // Model-based (MongoDB) endpoints
        [HttpGet("mongo")]
        public async Task<IActionResult> GetAllMongo() => Ok(await _service.GetAllMongoAsync());
        [HttpGet("mongo/{id}")]
        public async Task<IActionResult> GetByIdMongo(string id) => Ok(await _service.GetByIdMongoAsync(id));
        [HttpPost("mongo")]
        public async Task<IActionResult> AddMongo([FromBody] Prescription entity)
        {
            await _service.AddMongoAsync(entity);
            return CreatedAtAction(nameof(GetByIdMongo), new { id = entity.Id }, entity);
        }
        [HttpPut("mongo/{id}")]
        public async Task<IActionResult> UpdateMongo(string id, [FromBody] Prescription entity)
        {
            entity.Id = id;
            await _service.UpdateMongoAsync(entity);
            return NoContent();
        }
        [HttpDelete("mongo/{id}")]
        public async Task<IActionResult> DeleteMongo(string id)
        {
            await _service.DeleteMongoAsync(id);
            return NoContent();
        }
    }
}
