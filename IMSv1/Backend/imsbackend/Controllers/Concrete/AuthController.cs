using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.Entities.Concrete;
using ImmovableManagementSystem.Entities.DTOs;

namespace imsbackend.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthInterface _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(AuthInterface authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (await _authRepository.UserExists(registerDTO.Email))
                {
                    ModelState.AddModelError("Email", "Email is already taken");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userToCreate = new User
                {
                    Name = registerDTO.Name,
                    Surname = registerDTO.Surname,
                    Email = registerDTO.Email,
                    Phone = registerDTO.Phone,
                    Address = registerDTO.Address,
                    Role = registerDTO.Role
                };

                var createdUser = await _authRepository.Register(userToCreate, registerDTO.Password);
                return StatusCode(201); // Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _authRepository.Login(loginDTO.Email, loginDTO.Password);
                if (user == null)
                {
                    return Unauthorized();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Appsettings:Token").Value);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            try
            {
                var user = await _authRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
