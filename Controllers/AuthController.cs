using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IValidator<UserDto> _userDtoValidator;

        public AuthController(TokenService tokenService, IValidator<UserDto> userDtoValidator)
        {
            _tokenService = tokenService;
            _userDtoValidator = userDtoValidator;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var validationResult = await _userDtoValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Assuming the logic for registering a user goes here
            var token = _tokenService.GenerateToken(userDto.Username, "user");  // Assume "user" role for now
            return Ok(new { Token = token });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var validationResult = await _userDtoValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Assuming the logic for login goes here
            var token = _tokenService.GenerateToken(userDto.Username, "user");
            return Ok(new { Token = token });
        }
    }
}
