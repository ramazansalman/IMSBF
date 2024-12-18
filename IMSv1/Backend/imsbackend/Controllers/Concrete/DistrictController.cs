using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Entities.Concrete;

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
            var result = await _districtService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var district = await _districtService.GetByIdAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        [HttpGet("by-city/{cityId}")]
        public async Task<IActionResult> GetByCityId(int cityId)
        {
            var districts = await _districtService.GetByCityIdAsync(cityId);

            if (districts == null || !districts.Any())
            {
                return NotFound();
            }

            return Ok(districts);
        }
    }
}