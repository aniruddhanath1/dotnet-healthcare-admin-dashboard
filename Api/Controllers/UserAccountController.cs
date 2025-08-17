using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_admin_dashboard.Domain.Entities;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using dotnet_admin_dashboard.Application.DTOs;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _service;
        public UserAccountController(IUserAccountService service)
        {
            _service = service;
        }
        // DTO-based endpoints
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllDto() => Ok(await _service.GetAllAsync());
        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetDto(int id) => Ok(await _service.GetByIdAsync(id));
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] UserAccountDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetDto), new { id = dto.Id }, dto);
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] UserAccountDto dto)
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
        public async Task<ActionResult<IEnumerable<UserAccount>>> GetAll() => Ok(await _service.GetAllMongoAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccount>> GetById(int id)
        {
            var result = await _service.GetByIdMongoAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<UserAccount>> Add([FromBody] UserAccount userAccount)
        {
            await _service.AddMongoAsync(userAccount);
            return CreatedAtAction(nameof(GetById), new { id = userAccount.Id }, userAccount);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserAccount>> Update(int id, [FromBody] UserAccount userAccount)
        {
            if (id != userAccount.Id) return BadRequest();
            await _service.UpdateMongoAsync(userAccount);
            return Ok();
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
