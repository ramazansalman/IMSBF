using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Business.Concrete.Services;
using imsbackend.Entities.Concrete;

namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImmovableController : ControllerBase
    {
        private readonly ImmovableInterface _immovableService;

        public ImmovableController(ImmovableInterface immovableService)
        {
            _immovableService = immovableService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _immovableService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tasinmaz = await _immovableService.GetByIdAsync(id);

            if (tasinmaz == null)
            {
                return NotFound();
            }

            return Ok(tasinmaz);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var tasinmazlar = await _immovableService.GetByUserIdAsync(userId);
            return Ok(tasinmazlar);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Immovable immovable)
        {
            var createdTasinmaz = await _immovableService.AddAsync(immovable);
            return CreatedAtAction(nameof(GetById), new { id = createdTasinmaz.Id }, createdTasinmaz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Immovable immovable)
        {
            var updatedTasinmaz = await _immovableService.UpdateAsync(id, immovable);
            if (updatedTasinmaz == null)
            {
                return NotFound();
            }

            return Ok(updatedTasinmaz);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _immovableService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}