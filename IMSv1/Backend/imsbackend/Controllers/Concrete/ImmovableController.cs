using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using imsbackend.DataAccess;
using System.Linq;


namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImmovableController : ControllerBase
    {
        private readonly ImmovableInterface _immovableService;
        private readonly AppDbContext _context;

        public ImmovableController(ImmovableInterface immovableService, AppDbContext context)
        {
            _immovableService = immovableService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _immovableService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var immovable = await _immovableService.GetByIdAsync(id);
                if (immovable == null)
                {
                    return NotFound();
                }
                return Ok(immovable);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var immovablelar = await _immovableService.GetByUserIdAsync(userId);
                return Ok(immovablelar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Immovable immovable)
        {
            try
            {
                var createdTasinmaz = await _immovableService.AddAsync(immovable);
                return CreatedAtAction(nameof(GetById), new { id = createdTasinmaz.Id }, createdTasinmaz);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Immovable immovable)
        {
            try
            {
                var updatedTasinmaz = await _immovableService.UpdateAsync(id, immovable);
                if (updatedTasinmaz == null)
                {
                    return NotFound();
                }
                return Ok(updatedTasinmaz);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _immovableService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("deleteMultiple")]
        public IActionResult DeleteMultiple([FromBody] List<int> ids)
        {
            if (ids == null || !ids.Any()) // Check if list is null or empty
            {
                return BadRequest("No IDs provided.");
            }

            try
            {
                var immovablesToDelete = _context.Immovables.Where(i => ids.Contains(i.Id)).ToList();

                if (immovablesToDelete.Any())
                {
                    _context.Immovables.RemoveRange(immovablesToDelete);
                    _context.SaveChanges();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
