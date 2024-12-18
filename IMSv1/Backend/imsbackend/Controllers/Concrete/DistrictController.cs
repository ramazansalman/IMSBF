using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;

namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DistrictInterface _districtService;

        public DistrictController(DistrictInterface districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _districtService.GetAll();
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
                var district = await _districtService.GetByIdAsync(id);
                if (district == null)
                {
                    return NotFound();
                }
                return Ok(district);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("by-city/{cityId}")]
        public async Task<IActionResult> GetByCityId(int cityId)
        {
            try
            {
                var districts = await _districtService.GetByCityIdAsync(cityId);
                if (districts == null || !districts.Any())
                {
                    return NotFound();
                }
                return Ok(districts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
