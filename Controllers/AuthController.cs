using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTO;
using WebApplication5.Interface;  // Use ITokenService interface

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IValidator<UserDto> _userDtoValidator;

        public AuthController(ITokenService tokenService, IValidator<UserDto> userDtoValidator)
        {
            _tokenService = tokenService;
            _userDtoValidator = userDtoValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var validationResult = await _userDtoValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var token = _tokenService.GenerateToken(userDto.Username, "user");
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var validationResult = await _userDtoValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var token = _tokenService.GenerateToken(userDto.Username, "user");
            return Ok(new { Token = token });
        }
    }
}
