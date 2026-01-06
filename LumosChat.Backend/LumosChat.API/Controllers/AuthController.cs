using LumosChat.Application.Abstractions;
using LumosChat.Application.DTOs;
using LumosChat.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LumosChat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            try
            {
                var user = await _authService.RegisterAsync(dto);

                return Ok(
                    new
                    {
                        user.Id,
                        user.Username,
                        user.AvatarUrl,
                        Message = "User register successfully!",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
