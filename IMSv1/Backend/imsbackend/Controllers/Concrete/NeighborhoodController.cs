using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var result = await _neighborhoodService.GetAll();
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
                var neighborhood = await _neighborhoodService.GetByIdAsync(id);

                if (neighborhood == null)
                {
                    return NotFound();
                }

                return Ok(neighborhood);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("by-district/{districtId}")]
        public async Task<IActionResult> GetByDistrictId(int districtId)
        {
            try
            {
                var neighborhoods = await _neighborhoodService.GetByDistrictIdAsync(districtId);

                if (neighborhoods == null || !neighborhoods.Any())
                {
                    return NotFound();
                }

                return Ok(neighborhoods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
