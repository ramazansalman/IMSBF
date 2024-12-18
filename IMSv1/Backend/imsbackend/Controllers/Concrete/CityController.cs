using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Entities.Concrete;

namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityInterface _city;

        public CityController(CityInterface city)
        {
            _city = city;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _city.GetAll();
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
                var city = await _city.GetByIdAsync(id);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
