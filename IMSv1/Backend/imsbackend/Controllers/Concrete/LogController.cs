using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Entities.Concrete;

namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogInterface _service;

        public LogController(LogInterface service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetAllLog()
        {
            try
            {
                var logs = await _service.ListLog();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> GetLogById(int id)
        {
            try
            {
                var log = await _service.GetLogById(id);
                if (log == null)
                {
                    return NotFound();
                }
                return log;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Log>> AddLog(Log log)
        {
            try
            {
                await _service.AddLog(log);
                return CreatedAtAction(nameof(GetLogById), new { id = log.Id }, log);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLog(int id, Log log)
        {
            try
            {
                if (id != log.Id)
                {
                    return BadRequest();
                }

                await _service.UpdateLog(log);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            try
            {
                await _service.DeleteLog(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchLogs(string term)
        {
            try
            {
                var logs = await _service.SearchLogsAsync(term);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
