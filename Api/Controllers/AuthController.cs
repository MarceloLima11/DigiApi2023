using Application.DTOs.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRegisterService _registerService;

        public AuthController(IAuthService authService, IRegisterService registerService)
        {
            _authService = authService;
            _registerService = registerService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            try
            {
                var result = await _authService.GenerateToken(user);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Unauthorized(err.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO user)
        {
            try
            {
                var result = await _registerService.Register(user);
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}