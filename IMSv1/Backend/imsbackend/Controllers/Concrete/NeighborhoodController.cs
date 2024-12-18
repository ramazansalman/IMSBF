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
    public class NeighborhoodController : ControllerBase
    {
        private readonly NeighborhoodInterface _neighborhoodService;

        public NeighborhoodController(NeighborhoodInterface neighborhoodService)
        {
            _neighborhoodService = neighborhoodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _neighborhoodService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var neighborhood = await _neighborhoodService.GetByIdAsync(id);

            if (neighborhood == null)
            {
                return NotFound();
            }

            return Ok(neighborhood);
        }

        [HttpGet("by-district/{districtId}")]
        public async Task<IActionResult> GetByDistrictId(int districtId)
        {
            var neighborhoods = await _neighborhoodService.GetByDistrictIdAsync(districtId);

            if (neighborhoods == null || !neighborhoods.Any())
            {
                return NotFound();
            }

            return Ok(neighborhoods);
        }
    }
}