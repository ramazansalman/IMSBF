using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Entities.Concrete;
using System;

namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userService;

        public UserController(UserInterface userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateAsync(id, userInfo);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new { Message = $"User with ID {id} was not found." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (if you have a logger, you can use it here)
                // _logger.LogError(ex, "An error occurred while deleting the user.");

                // Return a generic error message
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }

    }
}